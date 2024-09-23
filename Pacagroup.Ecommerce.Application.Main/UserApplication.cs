using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;


namespace Pacagroup.Ecommerce.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;
        private readonly IUserDomain _userDomain;

        public UserApplication(IMapper mapper, IAppLogger<CustomerApplication> logger, IUserDomain userDomain)
        {
            _mapper = mapper;
            _logger = logger;
            _userDomain = userDomain;
        }

        public Response<UserDto> Authenticate(UserLoginDto userLoginDto)
        {
            Response<UserDto> response = new Response<UserDto>();

            try
            {
                Users user = _userDomain.Authenticate(userLoginDto.UserName, userLoginDto.Password);

                response.Data = _mapper.Map<UserDto>(user);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Autenticación exitosa";
                }
            }
            catch (InvalidOperationException)
            { 
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }
    }
}
