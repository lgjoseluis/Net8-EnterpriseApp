using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Swashbuckle.AspNetCore.Annotations;

using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Service.WebApi.Helpers;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserApplication _userApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUserApplication userApplication, IOptions<AppSettings> appSettings)
        {
            _userApplication = userApplication;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Authenticate a user",
            Description = "Authenticate a user"

        )]
        [SwaggerResponse(StatusCodes.Status200OK, "OK. User authenticated", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request. Validate the data sent in the request", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found. User does not exist", typeof(ProblemDetails))]
        public IActionResult Authenticate([FromBody] UserLoginDto userDto)
        {
            Response<UserDto> response = _userApplication.Authenticate(userDto);

            if (response.IsSuccess) 
            { 
                if (response.Data is null)
                    return NotFound(response.Message);

                response.Data.Token = BuildToken(response.Data);

                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        private string BuildToken(UserDto userDto) 
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userDto.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials  = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
