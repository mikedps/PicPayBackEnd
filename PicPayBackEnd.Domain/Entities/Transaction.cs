using PicPayBackEnd.Domain.Primitives;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Entities
{
    public class Transaction : Entity
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public Payee Payee { get; private set; }
        public Payer Payer { get; private set; }

        public Money Amount { get; private set; }

        public Guid FkPayee { get; private set; }

        public Guid FkPayer { get; private set; }
    }
}
