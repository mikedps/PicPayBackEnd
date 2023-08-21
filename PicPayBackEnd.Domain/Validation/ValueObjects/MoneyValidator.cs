using FluentValidation;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Validation.ValueObjects
{
    public class MoneyValidator : AbstractValidator<Money>
    {
        public MoneyValidator()
        {
            //TODO: definir regras.
            RuleFor(e => e.Value).NotNull();
        }
    }
}
