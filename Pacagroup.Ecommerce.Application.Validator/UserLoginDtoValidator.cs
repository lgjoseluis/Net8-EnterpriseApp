using FluentValidation;

using Pacagroup.Ecommerce.Application.DTO;

namespace Pacagroup.Ecommerce.Application.Validator;

public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(c => c.Password)
                .NotNull().WithMessage("EL password es requerido")
                .NotEmpty().WithMessage("EL password no permite valores vacíos");

        RuleFor(c => c.UserName)
            .NotEmpty().WithMessage("Nombre de usuario no permite valores vacíos")
            .NotNull().WithMessage("Nombre del usuario es requerido");
    }
}

