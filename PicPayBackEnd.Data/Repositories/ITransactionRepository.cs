using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Repositories
{
    public interface ITransactionRepository
    {
        bool Create(Transaction transaction);

        IEnumerable<TransactionDTO> GetTransactions();

    }
}
