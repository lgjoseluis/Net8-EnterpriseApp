using System.Data;
using System.Threading.Tasks;

using Dapper;

using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region sync methods
        public bool Insert(Customer customer)
        {
            string command = "CustomerInsert";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("CustomerID",customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);
            

            using ( IDbConnection connection = _connectionFactory.GetConnection)
            { 
                int result = connection.Execute(command, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool Update(Customer customer)
        {
            string command = "CustomerUpdate";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("CustomerID", customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);


            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                int result = connection.Execute(command, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool Delete(string customerId)
        {
            string command = "CustomerDelete";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("CustomerID", customerId);

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                int result = connection.Execute(command, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public Customer Get(string customerId)
        {
            string command = "CustomerGetById";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("CustomerID", customerId);

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                Customer customer = connection.QuerySingle<Customer>(command, parameters, commandType: CommandType.StoredProcedure);

                return customer;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            string command = "CustomerList";

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                IEnumerable<Customer> customers = connection.Query<Customer>(command,commandType: CommandType.StoredProcedure);

                return customers;
            }
        }
        #endregion

        #region async methods
        public async Task<bool> InsertAsync(Customer customer)
        {
            string command = "CustomerInsert";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("CustomerID", customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);


            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                int result = await connection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }        

        public async Task<bool> UpdateAsync(Customer customer)
        {
            string command = "CustomerUpdate";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("CustomerID", customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);


            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                int result = await connection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            string command = "CustomerDelete";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("CustomerID", customerId);

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                int result = await connection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
        public async Task<Customer> GetAsync(string customerId)
        {
            string command = "CustomerGetById";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("CustomerID", customerId);

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                Customer customer = await connection.QuerySingleAsync<Customer>(command, parameters, commandType: CommandType.StoredProcedure);

                return customer;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            string command = "CustomerList";

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                IEnumerable<Customer> customers = await connection.QueryAsync<Customer>(command, commandType: CommandType.StoredProcedure);

                return customers;
            }
        }
        #endregion
    }
}
