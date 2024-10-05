using System.Data;

using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Application.Interface.Persistence;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
