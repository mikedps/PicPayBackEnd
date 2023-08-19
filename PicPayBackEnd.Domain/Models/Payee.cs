using PicPayBackEnd.Domain.Primitives;
using PicPayBackEnd.Domain.ValueObjects;

namespace PicPayBackEnd.Domain.Models
{
    public class Payee : Entity
    {
        private Payee()
        {
        }
        public Payee(User user)
        {
            User = user;
            Balance = Money.Empty();
        }

        public User User { get; private set; }

        public Money Balance { get; private set; }


        public IList<Transaction> Transactions { get; private set; }

    }
}
