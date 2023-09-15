using Microsoft.EntityFrameworkCore;
using PicPayBackEnd.Data.Context;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        
        private readonly PicPayContext _context;

        public TransactionRepository(PicPayContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);

            await _context.SaveChangesAsync();

            return transaction.Id;
        }


      /*  public async Task<IEnumerable<TransactionDTO>> GetTransactionsAsync()
        {
            return await _context.Transactions
                .Take(50)
                .Select(x => new TransactionDTO
            {
                Created = x.Date,
                Id = x.Id,
                Payee = x.FkPayee,
                Payer = x.FkPayer
            })
            .OrderByDescending(x=>x.Created)
            .ToListAsync();
        }
      */
    }
}
