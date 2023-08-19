using PicPayBackEnd.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }
        public Money(decimal value) { Value = value; }


        public static Money Empty() => new Money(0);
    }
}
