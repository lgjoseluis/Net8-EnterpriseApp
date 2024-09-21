using FluentValidation;

using Pacagroup.Ecommerce.Application.DTO;

namespace Pacagroup.Ecommerce.Application.Validator
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(c => c.CustomerId)
                .NotNull().WithMessage("EL ID es requerido")
                .NotEmpty().WithMessage("EL ID no permite valores vacíos");

            RuleFor(c => c.CompanyName)
                .NotEmpty().WithMessage("Nombre de la compañia no permite valores vacíos")
                .NotNull().WithMessage("Nombre de la compañia es requerido");

            RuleFor(c => c.ContactName)
                .NotEmpty().WithMessage("Nombre de contacto no permite valores vacíos")
                .NotNull().WithMessage("Nombre del contacto es requerido");
        }
    }
}
