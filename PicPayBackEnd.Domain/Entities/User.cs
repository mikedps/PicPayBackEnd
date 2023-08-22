using PicPayBackEnd.Domain.Enums;
using PicPayBackEnd.Domain.Primitives;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Domain.Entities
{
    public class User : Entity
    {
        private User() { }
        private User(string? name, string? surname, UserType userType, DocumentID documentID, Email email)
        {
            Name = name;
            Surname = surname;
            UserType = userType;
            DocumentID = documentID;
            Email = email;
            Balance = Money.Empty;
        }


        public string? Name { get; private set; }

        public string? Surname { get; private set; }

        public UserType UserType { get; private set; }

        public DocumentID DocumentID { get; private set; }

        public Email Email { get; private set; }
        
        public Money Balance { get; private set; }

        public static User CreateUser(string? name, 
            string? surname, 
            UserType userType, 
            DocumentID documentID, 
            Email email)
        {
            return new User(name, surname, userType, documentID, email);
        }


        public void SetUserType(UserType userType) => UserType = userType;

        public void SetBalance(Money balance) => Balance = balance;

        public IList<Transaction> PayeeTransactions { get; private set; }

        public IList<Transaction> PayerTransactions { get; private set; }


    }
}
