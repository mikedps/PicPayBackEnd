using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Models
{
    public class User 
    {
        private User() { }
        public User(string? name, string? surename, Cpf? cpf, Email? email)
        {
            Name = name;
            Surename = surename;
            Cpf = cpf;
            Email = email;
        }

        public string? Name { get; private set; }

        public string? Surename { get; private set; }

        public Cpf? Cpf { get; private set; }

        public Email? Email { get; private set; }

        public string FullName => $"{Name} {Surename}";

    }
}
