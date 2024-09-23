using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Domain.Interface;

public interface IUserDomain
{
    Users Authenticate(string username, string password);
}

