using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core;

public class UserDomain : IUserDomain
{
    private readonly IUserRepository _userRepository;

    public UserDomain(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Users Authenticate(string username, string password)
    {
        return _userRepository.Authenticate(username, password);
    }
}

