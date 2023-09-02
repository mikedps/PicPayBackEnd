using MediatR;
using PicPayBackEnd.Data.Commands;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Data.Repositories;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Exceptions;
using PicPayBackEnd.Domain.ValueObjects;

namespace PicPayBackEnd.Data.Handlers
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Result>
    {
        private readonly ITransactionRepository _repository;
        private readonly IUserRepository _userRepository;

        public CreateTransactionCommandHandler(ITransactionRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();
            var payee = await _userRepository.GetByIdAsync(request.Payee);
            var payer = await _userRepository.GetByIdAsync(request.Payer);

            if (payee == null || payer == null)
            {
                result.AddError("A valid Payee and Payer is required.");
                return result;
            }

            try
            {
                var transaction = Transaction.Create(payer, payee, Money.Create(request.Amount));

                await _repository.CreateAsync(transaction);
            }
            catch (TransactionException ex)
            {
                result.AddError(ex.Message);
            }

            return result;

        }
    }
}
