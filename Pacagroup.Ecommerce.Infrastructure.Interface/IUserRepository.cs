using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Infrastructure.Interface;

public interface IUserRepository
{
    User Authenticate(string userName, string password);
}

