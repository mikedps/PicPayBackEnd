using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Enums;
using PicPayBackEnd.Domain.Exceptions;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PicPayBackEnd.Tests
{
    public class TransactionTests
    {

        private readonly User _validPayer;
        private readonly User _validPayee;

        public TransactionTests()
        {
            var doc = DocumentID.Create("36646320870");
            var email = Email.Create("mikedps@gmail.com");
            _validPayer = User.Create("Mike", "Pires", UserType.Padrao, doc, email);
            _validPayee = User.Create("Thais", "Del", UserType.Padrao, doc, email);
        }

        [Fact(DisplayName ="Create Transaction")]
        public void Transaction_CreateTransaction()
        {
            var amount = Money.Empty;
            Assert.Throws<TransactionException>(() => Transaction.Create(_validPayer, _validPayee, amount));
        }

        [Fact(DisplayName = "Create Transaction Tipo de Usuário Inválido")]
        public void Transaction_NotAllowed_User_Type()
        {
            var amount = Money.Create(100);
            _validPayer.SetUserType(UserType.Lojista);
            Assert.Throws<TransactionException>(() => Transaction.Create(_validPayer, _validPayee, amount));
        }


        [Fact(DisplayName = "Create Transaction valor de transferencia maior que saldo")]
        public void Transaction_NotAllowed_Insufficient_Funds()
        {
            var amount = Money.Create(800);
            _validPayer.SetBalance(Money.Create(99.99M));
            Assert.Throws<TransactionException>(() => Transaction.Create(_validPayer, _validPayee, amount));
        }

        [Fact(DisplayName = "Update Payee/Payer Balance")]
        public void Transaction_PayeePayer_Balance()
        {
            _validPayer.SetBalance(Money.Create(999M));
            var amount = Money.Create(999M);

            Transaction.Create(_validPayer, _validPayee, amount);

            Assert.Equal(0, _validPayer.Balance.Value);
            Assert.Equal(999, _validPayee.Balance.Value);

        }

    }
}
