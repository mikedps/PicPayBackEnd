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
    {        private readonly PicPayContext _context;

        public TransactionRepository(PicPayContext context)
        {
            _context = context;
        }

        public bool Create(Transaction transaction)
        {
            _context.Transactions.Add(transaction);

            return _context.SaveChanges() > 0;
        }


        public IEnumerable<TransactionDTO> GetTransactions()
        {
            return _context.Transactions
                .Take(50)
                .Select(x => new TransactionDTO
            {
                Created = x.Date,
                Id = x.Id,
                Payee = x.FkPayee,
                Payer = x.FkPayer
            })
            .OrderByDescending(x=>x.Created)
            .ToList();
        }
    }
}
