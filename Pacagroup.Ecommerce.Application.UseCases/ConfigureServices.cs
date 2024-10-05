using Microsoft.Extensions.DependencyInjection;

using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.UseCases.CustomersApp;
using Pacagroup.Ecommerce.Application.UseCases.UsersApp;

namespace Pacagroup.Ecommerce.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<IUserApplication, UserApplication>();

            return services;
        }
    }
}
