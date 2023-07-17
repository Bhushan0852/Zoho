using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoho.Dapper.Interfaces;

namespace Zoho.Dapper
{
    public class DapperDbContext  
    {
        private readonly IConfiguration configuration;
        public DapperDbContext(IConfiguration configuration)
        {
            this.configuration = configuration; 
        }

        //public IDbConnection CreateConnection() => new SqlConnection(configuration.GetConnectionString("ZohoConnectionString"));
    }
}
