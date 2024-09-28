using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Pacagroup.Ecommerce.Infrastructure.Repository;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Application.Main;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Domain.Core;
using Pacagroup.Ecommerce.Transversal.Logging;
using System.Data;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddTransient<IDbConnection>(sp => {
                 return sp.GetRequiredService<DapperContext>().CreateConnection();
            });
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ICustomerDomain, CustomerDomain>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
