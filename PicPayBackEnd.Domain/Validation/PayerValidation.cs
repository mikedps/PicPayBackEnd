using FluentValidation;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Utils;
using PicPayBackEnd.Domain.Validation.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Validation
{
    public class PayerValidation : AbstractValidator<Payer>
    {
        public PayerValidation()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Payer ID must not be empty");

            RuleFor(p => p.User).SetValidator(new UserValidation());


        }
    }
}
