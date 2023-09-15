using PicPayBackEnd.Domain.Events;
using PicPayBackEnd.Domain.Exceptions;
using PicPayBackEnd.Domain.Primitives;
using PicPayBackEnd.Domain.ValueObjects;

namespace PicPayBackEnd.Domain.Entities
{
    public class Transaction : AggregateRoot
    {

        private Transaction() { }
        private Transaction(User payer, User payee, Money amount)
        {
            Payer = payer;
            Payee = payee;
            Amount = amount;
            Date = DateTime.Now;            
        }
        public DateTime Date { get; private set; }
        public Money Amount { get; private set; }
        public Guid FkPayee { get; private set; }
        public Guid FkPayer { get; private set; }
        public User Payee { get; private set; }
        public User Payer { get; private set; }



        public static Transaction Create(User payer, User payee, Money amount)
        {
            if(payer.UserType == Enums.UserType.Lojista)
            {
                throw new TransactionException("Lojista não pode realizar pagamento");
            }

            if (amount.Value <= 0)
            {
                throw new TransactionException("Valor da Transação não pode ser menor que zero");
            }

            if(payer.Balance.Value < amount.Value)
            {
                throw new TransactionException("Saldo insuficiente");
            }

            var saldoPayer = payer.Balance.Value - amount.Value;
            var saldoPayee = payee.Balance.Value + amount.Value;

            payee.SetBalance(Money.Create(saldoPayee));
            payer.SetBalance(Money.Create(saldoPayer));


            var transaction = new Transaction(payer, payee, amount);

            transaction.RaiseEvent(new TransactionCreatedEvent(transaction));

            return transaction;
            
        }
    }
}
