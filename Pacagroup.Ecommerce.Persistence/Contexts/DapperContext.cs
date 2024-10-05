using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pacagroup.Ecommerce.Persistence.Contexts
{
    public class DapperContext
    {
        private readonly string? _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("NorthwindConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
