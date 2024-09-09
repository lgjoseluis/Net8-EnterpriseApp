using System.Data;
using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;

using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get { 
                SqlConnection sqlConnection = new SqlConnection();

                /*if (sqlConnection is null) 
                    return null;*/

                sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");

                sqlConnection.Open();

                return sqlConnection; 
            }
        }
    }
}
