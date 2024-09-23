using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Infrastructure.Interface;

public interface IUserRepository : IGenericRepository<Users>
{
    Users Authenticate(string userName, string password);
}

