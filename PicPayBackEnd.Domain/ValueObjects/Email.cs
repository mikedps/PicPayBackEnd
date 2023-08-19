using PicPayBackEnd.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; private set; }
        public Email(string value) => Value = value; 
    }
}
