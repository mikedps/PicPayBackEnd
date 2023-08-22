using PicPayBackEnd.Domain.Primitives;

namespace PicPayBackEnd.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }
        public Money(decimal value) { Value = value; }

        public static Money Empty => new Money(0);

        public static Money Create(decimal value) => new Money(value);
    }
}
