using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Data.Repositories;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Exceptions;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IUserRepository _userRepository;

        public TransactionService(ITransactionRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<Result> CreateTransaction(TransactionDTO request)
        {
            var result = new Result();
            var payee = await _userRepository.GetByIdAsync(request.Payee);
            var payer = await _userRepository.GetByIdAsync(request.Payer);

            if(payee == null || payer == null)
            {
                result.AddError("A valid Payee and Payer is required.");
                return result;
            }

            try
            {
                var transaction = Transaction.Create(payer, payee, Money.Create(request.Amount));

                await _repository.CreateAsync(transaction);
            }
            catch(TransactionException ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}
