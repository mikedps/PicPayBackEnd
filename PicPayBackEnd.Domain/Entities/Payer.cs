using PicPayBackEnd.Domain.Primitives;
using PicPayBackEnd.Domain.ValueObjects;

namespace PicPayBackEnd.Domain.Entities
{
    public class Payer : Entity
    {
        private Payer()
        {
        }
        private Payer(User user)
        {
            User = user;
            Balance = Money.Empty();
        }

        public User User { get; private set; }

        public Money Balance { get; private set; }

        public static Payer CreatePayer(User user)
        {
            return new Payer(user);
        }




        public IList<Transaction> Transactions { get; private set; }

    }
}
