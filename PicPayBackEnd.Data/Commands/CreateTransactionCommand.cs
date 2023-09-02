using MediatR;
using PicPayBackEnd.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Commands
{
    public class CreateTransactionCommand : IRequest<Result>
    {
        public DateTime Created { get; set; }
        public Guid Payer { get; set; }
        public Guid Payee { get; set; }
        public decimal Amount { get; set; }

    }
}
