using AutoMapper;

using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Application.UseCases.UsersApp
{
    public class UserApplication : IUserApplication
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<UserApplication> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserApplication(IMapper mapper, IAppLogger<UserApplication> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public Response<UserDto> Authenticate(UserLoginDto userLoginDto)
        {
            Response<UserDto> response = new Response<UserDto>();

            try
            {
                Users user = _unitOfWork.Users.Authenticate(userLoginDto.UserName, userLoginDto.Password);

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
