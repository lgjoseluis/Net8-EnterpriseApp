using AutoMapper;

using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Domain.Entities;

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
            ArgumentNullException.ThrowIfNull(nameof(userLoginDto));

            Response<UserDto> response = new Response<UserDto>();

            if (string.IsNullOrEmpty(userLoginDto.UserName) || string.IsNullOrEmpty(userLoginDto.Password))
            {
                response.Message = "Datos de usuario inválidos";

                return response;
            }

            try
            {
                Users user = _unitOfWork.Users.Authenticate(userLoginDto.UserName, userLoginDto.Password);

                response.Data = _mapper.Map<UserDto>(user);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Autenticación exitosa";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
                _logger.LogError(response.Message);
            }

            return response;
        }
    }
}
