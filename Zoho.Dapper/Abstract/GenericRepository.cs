using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Zoho.Dapper.Interfaces;
using Zoho.Domain;

namespace Zoho.Dapper.Abstract
{
    public class GenericRepository : IGenericRepository //, IGenericDRepository<T>
    {
        //private readonly IClientDapperRepository clientDapperRepository;
        private readonly IConfiguration configuration;
        //private readonly DapperDbContext dbContext;
        private readonly string connStr;
        public GenericRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            //this.dbContext = dbContext;
            connStr = this.configuration.GetConnectionString("ZohoConnectionString");
            //this.clientDapperRepository = clientDapperRepository;
        }

        //public IDbConnection CreateConnection() => new SqlConnection(configuration.GetConnectionString("ZohoConnectionString"));
        //public IDbConnection CreateConnection() => new SqlConnection(connStr);
        public async Task<int> AddAsync(Client entity)
        {
            //entity.AddedOn = DateTime.Now;
            //var aa = clientDapperRepository.GetAllAsync
            var sql = "Insert into Products (Name,Description,Barcode,Rate,AddedOn) VALUES (@Name,@Description,@Barcode,@Rate,@AddedOn)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = 0;//await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }


        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = 0;// await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Client>> GetAllAsync()
        {
            var sql = "SELECT * FROM Clients";
            using (var connection = new SqlConnection(connStr))
            {
                var result = await connection.QueryAsync<Client>(sql);
                return result.ToList();
            }
        }

        //public Task<IReadOnlyList<T>> GetAllAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Client> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                Client c = new Client();
                var result = c;// await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Client entity)
        {
            //entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = 0;// await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }


    }
}
