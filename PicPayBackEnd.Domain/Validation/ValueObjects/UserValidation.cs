using FluentValidation;
using PicPayBackEnd.Domain.Entities;

namespace PicPayBackEnd.Domain.Validation.ValueObjects
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("É Obrigatório informar o nome.")
               .MinimumLength(2).WithMessage("Mínimo de 2 Caracteres para o nome.")
               .MaximumLength(200).WithMessage("Máximo de 200 Caracteres para o nome.");

            RuleFor(c => c.Surename)
                .NotNull().WithMessage("É Obrigatório informar o sobrenomee.")
               .MinimumLength(2).WithMessage("Mínimo de 2 Caracteres para o sobrenome.")
               .MaximumLength(200).WithMessage("Máximo de 200 Caracteres para o sobrenome.");


            RuleFor(p => p.Cpf).SetValidator(new CpfValidator());

            RuleFor(p => p.Email).SetValidator(new EmailValidator());
        }
    }
}
