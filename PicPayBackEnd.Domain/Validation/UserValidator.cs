using FluentValidation;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Enums;

namespace PicPayBackEnd.Domain.Validation.ValueObjects
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Payer ID must not be empty.");

            RuleFor(p => p.UserType)
                .Must(u => ValidUserType(u))
                .WithMessage("Invalid Type User");


            RuleFor(p => p.Balance.Value)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Valor do Saldo não pode ser menor que 0 (zero)");


            RuleFor(c => c.Name)
               .NotNull().WithMessage("É Obrigatório informar o nome.")
               .MinimumLength(2).WithMessage("Mínimo de 2 Caracteres para o nome.")
               .MaximumLength(200).WithMessage("Máximo de 200 Caracteres para o nome.");

            RuleFor(c => c.Surname)
               .NotNull().WithMessage("É Obrigatório informar o sobrenomee.")
               .MinimumLength(2).WithMessage("Mínimo de 2 Caracteres para o sobrenome.")
               .MaximumLength(200).WithMessage("Máximo de 200 Caracteres para o sobrenome.");

            RuleFor(p => p.DocumentID).SetValidator(new DocumentIDValidator());

            RuleFor(p => p.Email).SetValidator(new EmailValidator());
        }

        private bool ValidUserType(UserType userType)
        {
            return Enum.IsDefined(typeof(UserType), userType);
        }
    }
}
