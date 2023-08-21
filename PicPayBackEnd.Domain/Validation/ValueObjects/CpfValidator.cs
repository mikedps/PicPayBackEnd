using FluentValidation;
using PicPayBackEnd.Domain.Utils;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Validation.ValueObjects
{
    public class CpfValidator : AbstractValidator<Cpf>
    {
        public CpfValidator()
        {
            RuleFor(c => c.Value).NotEmpty().WithMessage("CPF inválido");

            When(x => !string.IsNullOrEmpty(x.Value), () =>
            {
                RuleFor(c => c.Value.Length)
                .Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.")
                 .OverridePropertyName(c => c.Value);


                RuleFor(c => CpfValidacao.Validar(c.Value))
                    .Equal(true).WithMessage("O documento fornecido é inválido.")
                     .OverridePropertyName(c => c.Value);
            });
        }
    }
}
