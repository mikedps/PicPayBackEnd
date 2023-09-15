using FluentValidation;
using PicPayBackEnd.Domain.Utils;
using PicPayBackEnd.Domain.ValueObjects;

namespace PicPayBackEnd.Domain.Validation.ValueObjects
{
    public class DocumentIDValidator : AbstractValidator<DocumentID>
    {
        public DocumentIDValidator()
        {
            RuleFor(c => c.Value).NotEmpty().WithMessage("DocumentID inválido");

            RuleFor(documento => documento)
               .NotEmpty().WithMessage("O documento é obrigatório.")
               .Must(x => Utils.Utils.IsValidDocument(x.Value))
               .WithMessage("O documento é inválido.");

        }

   
    }
}
