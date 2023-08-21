using FluentValidation;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Data.Repositories;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.ValueObjects;


namespace PicPayBackEnd.Data.Services
{
    public class PayerService : IPayerService
    {
        private readonly IPayerRepository _repository;

        public readonly IValidator<Payer> _validator;

        public PayerService(IPayerRepository repository, IValidator<Payer> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public Result CreatePayer(PayerDTO request)
        {
            var payer = Payer.CreatePayer(
                User.CreateUser(request.Name, request.Surename,
                    Cpf.CreateCpf(request.Cpf),
                    Email.CreateEmail(request.Email)));

            var validate = _validator.Validate(payer);

            var result = new Result();
            if(!validate.IsValid)
            {
                foreach(var error in validate.Errors)
                {
                    result.AddError(error.ErrorMessage);
                }

                result.Success = false;
                return result;
            }
            result.Success = true;
            _repository.Create(payer);

            return result;

        }
    }
}
