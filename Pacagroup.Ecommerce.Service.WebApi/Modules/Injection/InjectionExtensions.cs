using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Pacagroup.Ecommerce.Infrastructure.Repository;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Application.Main;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Domain.Core;
using Pacagroup.Ecommerce.Transversal.Logging;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<ICustomerApplication, CustomerApplication>();
            services.AddSingleton<ICustomerDomain, CustomerDomain>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
