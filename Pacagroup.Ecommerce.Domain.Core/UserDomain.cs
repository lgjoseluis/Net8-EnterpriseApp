using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core;

public class UserDomain : IUserDomain
{
    private readonly IUnitOfWork _unitOfWork;

    public UserDomain(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Users Authenticate(string username, string password)
    {
        return _unitOfWork.Users.Authenticate(username, password);
    }
}

