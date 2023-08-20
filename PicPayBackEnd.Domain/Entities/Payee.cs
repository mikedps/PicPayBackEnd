using PicPayBackEnd.Domain.Primitives;
using PicPayBackEnd.Domain.ValueObjects;

namespace PicPayBackEnd.Domain.Entities
{
    public class Payee : Entity
    {
        private Payee()
        {
        }
        private Payee(User user)
        {
            User = user;
            Balance = Money.Empty();
        }

        public User User { get; private set; }

        public Money Balance { get; private set; }


        public static Payee CreatePayee(User user)
        {
            return new Payee(user);
        }



        public IList<Transaction> Transactions { get; private set; }

    }
}
