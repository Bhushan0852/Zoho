using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using UnitOfWorkDemo.Core.Interfaces;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IConfiguration configuration;
        private readonly string connStr;
        public readonly string _tableName;
        protected GenericRepository(IConfiguration configuration, string tableName)
        {
            this.configuration = configuration;
            this.connStr = configuration.GetConnectionString("ZohoConnectionString");
            this._tableName = tableName;
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
        

        public async Task<T> GetById(int id)
        {
            using (var connection = new SqlConnection(connStr))
            {
                var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Id=@Id", new { Id = id });
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with id [{id}] could not be found.");
                return result;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var sql = "SELECT * FROM " + _tableName + " WHERE ISDELETED = 0";
            using (var connection = new SqlConnection(connStr))
            {
                var result = await connection.QueryAsync<T>(sql);
                return (IEnumerable<T>)result.ToList();
            }
        }
        public async Task<T> Delete(int id)
        {
            using (var connection = new SqlConnection(connStr))
            {
                var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Id=@Id", new { Id = id });
                if (result != null)
                {
                    var sql = "UPDATE " + _tableName + " SET IsDeleted = " + 1 + " Where Id = " + id;
                    var data = await connection.ExecuteAsync(sql);
                    if (data > 0)
                        return result;
                }
            }
            return null;
        }

        public async Task<T> UpdateAsync(T t)
        {
            var updateQuery = GenerateUpdateQuery();

            using (var connection = new SqlConnection(connStr))
            {
                await connection.ExecuteAsync(updateQuery, t);
                return t;
            }
            return null;
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"Update {_tableName} Set ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id") && !property.Equals("Currency") && !property.Equals("BillingMethod"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        public async Task<bool> Create(T t)
        {
            {
                var insertQuery = GenerateInsertQuery();
                
                using (var connection = new SqlConnection(connStr))
                {
                  var count =  await connection.ExecuteAsync(insertQuery, t);
                    if(count > 0)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => {
                if (prop != "Id" && prop != "Currency" && prop != "BillingMethod")
                {
                    insertQuery.Append($"[{prop}],");
                }
            });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => {
                if (prop != "Id" && prop != "Currency" && prop != "BillingMethod")
                {
                    insertQuery.Append($"@{prop},");
                }
            });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }

        public async Task<T> GetUser(string userName, string password)
        {
            using (var connection = new SqlConnection(connStr))
            {
                //var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Name=@userName and password=@password ", new { userName = userName , password = password });
                var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Name=@userName ", new { userName = userName});
                if (result == null)
                    throw new KeyNotFoundException("could not be found.");
                return result;
            }
        }
    }
}
