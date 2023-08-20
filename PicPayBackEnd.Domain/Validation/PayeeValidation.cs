using FluentValidation;
using PicPayBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Validation
{
    public class PayeeValidation : AbstractValidator<Payee>
    {
        public PayeeValidation()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Payee ID must not be empty");
        }
    }
}
