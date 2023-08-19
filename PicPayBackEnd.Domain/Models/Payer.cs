using PicPayBackEnd.Domain.Primitives;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Models
{
    public class Payer : Entity
    {
        private Payer()
        {
        }
        public Payer(User user)
        {
            User = user;
            Balance = Money.Empty();
        }

        public User User { get; private set; }

        public Money Balance { get; private set; }

        public IList<Transaction> Transactions { get; private set; }

    }
}
