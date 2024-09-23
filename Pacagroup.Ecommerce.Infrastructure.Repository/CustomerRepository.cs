using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(DapperContext context):base(context)
        {            
        }
    }
}
