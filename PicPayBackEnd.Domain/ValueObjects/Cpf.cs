using PicPayBackEnd.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.ValueObjects
{
    public class Cpf : ValueObject
    {
        public string Value { get; private set; }
        private Cpf(string value)
        {
            Value = value;
        }

        public static Cpf CreateCpf(string value) => new Cpf(value);
    }
}
