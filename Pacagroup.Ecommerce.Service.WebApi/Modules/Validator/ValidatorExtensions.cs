using FluentValidation;
using FluentValidation.AspNetCore;
using Pacagroup.Ecommerce.Application.Validator;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(options => {
                options.DisableDataAnnotationsValidation = true; // Deshabilita la validación automática
            });
            
            services.AddValidatorsFromAssemblyContaining<CustomerDtoValidator>();

            return services;
        }
    }
}
