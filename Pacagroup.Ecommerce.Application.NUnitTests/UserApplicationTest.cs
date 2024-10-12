using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;

namespace Pacagroup.Ecommerce.Application.NUnitTests
{
    [TestFixture]
    public class UserApplicationTest
    {
        private static WebApplicationFactory<Program> _webAppFactory;
        private static IServiceScopeFactory _serviceScopeFactory = null;

        [SetUp]
        public void Setup()
        {
            _webAppFactory = new CustomWebApplicationFactory();
            _serviceScopeFactory = _webAppFactory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [Test]
        public void Authenticate_NoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();

            //Arrange
            string userName = string.Empty;            
            var expected = "Datos de usuario inválidos";

            //Act
            var result = context!.Authenticate(new UserLoginDto() { UserName= userName });
            var actual = result.Message;

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Authenticate_SeEnviaUsuarioOPasswordIncorrecto_RetornarMensajeUsuarioNoExiste()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();

            //Arrange
            var userName = "juanito";
            var password = "123456";
            var expected = "Usuario no existe";

            //Act
            var result = context!.Authenticate(new UserLoginDto() { UserName = userName, Password = password });
            var actual = result.Message;

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Authenticate_SeEnviaUsuarioExistente_RetornarMensajeUsuarioAutenticado()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();

            //Arrange
            var userName = "jluis";
            var password = "123456";
            var expected = "Autenticación exitosa";

            //Act
            var result = context!.Authenticate(new UserLoginDto() { UserName = userName, Password = password });
            var actual = result.Message;

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TearDown]
        public void TearDown() 
        { 
            _webAppFactory?.Dispose();
        }
    }
}