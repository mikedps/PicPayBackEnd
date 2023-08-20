using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Validation;
using PicPayBackEnd.Domain.ValueObjects;
using Xunit;

namespace PicPayBackEnd.Tests
{
    public class PayeeTests
    {
        private PayeeValidation _validator;
        public PayeeTests()
        { 
            _validator = new PayeeValidation();        
        }

        [Fact(DisplayName ="Payee: Not Empty")]
        public void Payee_ID_Must_Not_Be_Empty()
        {
            var payee = Payee.CreatePayee(new User("Mike", "Pires", new Cpf("36646320870"), new Email("mikedps@gmail.com")));

            var result =  _validator.Validate(payee);

            Assert.True(result.IsValid);
        }
    }
}
