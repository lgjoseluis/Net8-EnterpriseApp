using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface.UseCases
{
    public interface IUserApplication
    {
        Response<UserDto> Authenticate(UserLoginDto userLoginDto);
    }
}
