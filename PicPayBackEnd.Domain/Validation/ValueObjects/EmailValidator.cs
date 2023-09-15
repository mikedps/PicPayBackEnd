using FluentValidation;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Validation.ValueObjects
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(e => e.Value)
               .NotNull().WithMessage("Email é obrigatório")
               .MaximumLength(200).WithMessage("Preencha um email válido")
               .EmailAddress().WithMessage("Email precisa ser válido");
        }
    }
}
