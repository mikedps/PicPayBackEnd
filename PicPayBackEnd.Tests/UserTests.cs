using FluentValidation;
using FluentValidation.TestHelper;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Enums;
using PicPayBackEnd.Domain.Validation.ValueObjects;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PicPayBackEnd.Tests
{
    public class UserTests
    {
        private IValidator<DocumentID> _validator;
        private IValidator<User> _userValidator;
        public UserTests()
        {
            //var email = Email.CreateEmail("mikedps@gmail.com");
            //var usuario = User.CreateUser("Mike", "Pires", Domain.Enums.UserType.Padrao, doc, email);

            _validator = new DocumentIDValidator();
            _userValidator = new UserValidator();
        }

        [Theory(DisplayName ="Novo Usuário: Documento precisa ser válido")]
        [InlineData("000000000")]
        [InlineData("15.765.064/0001-500")]
        [InlineData("")]
        public void User__Create_User_Must_Have_Valid_DocumentID(string documento)
        {
            var doc = DocumentID.Create(documento);

            var resposta = _validator.Validate(doc);

            Assert.False(resposta.IsValid);

           
        }

        [Theory(DisplayName = "Novo Usuário: CPF ter o tipo certo")]
        [InlineData("366.463.208-70")]
        [InlineData("36646320870")]
        public void User__Create_User_Must_Have_CPF(string documento)
        {
            var doc = DocumentID.Create(documento);
            Assert.True(doc.Type == Domain.Enums.DocumentType.CPF);
        }

        [Theory(DisplayName = "Novo Usuário: CNPJ ter o tipo certo")]
        [InlineData("22023152000142")]
        [InlineData("15.765.064/0001-50")]
        public void User__Create_User_Must_Have_CNPJ(string documento)
        {
            var doc = DocumentID.Create(documento);
            Assert.True(doc.Type == Domain.Enums.DocumentType.CPNJ);
        }

        [Theory(DisplayName = "Novo Usuário: NONE ter o tipo certo")]
        [InlineData("0")]
        [InlineData("15.765.060004/0001-50")]
        [InlineData("9092049439")]
        public void User__Create_User_Must_Have_NONE(string documento)
        {
            var doc = DocumentID.Create(documento);
            Assert.True(doc.Type == Domain.Enums.DocumentType.None);
        }

        [Fact(DisplayName="Usuário Existente: Não pode ter saldo negativo")]
        public void User__Must_Not_Have_Negative_Balance()
        {
            var doc = DocumentID.Create("36646320870");
            var email = Email.Create("mikedps@gmail.com");
            var validPayer = User.Create("Thais", "Del", UserType.Padrao, doc, email);

            validPayer.SetBalance(Money.Create(-300M));

            Assert.False(_userValidator.Validate(validPayer).IsValid);

            

        }
    }
}
