using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence;

public interface IUserRepository : IGenericRepository<Users>
{
    Users Authenticate(string userName, string password);
}

