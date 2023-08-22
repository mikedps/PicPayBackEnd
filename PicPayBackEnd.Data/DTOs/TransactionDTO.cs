using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.DTOs
{
    public class TransactionDTO
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public Guid Payer { get; set; }
        public Guid Payee { get; set; }

        public decimal Amount { get; set; }
    }
}
