using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace CRUD_DAPPER.DBContext
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
