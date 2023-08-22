using Microsoft.Identity.Client;
using PicPayBackEnd.Data.Context;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PicPayContext _context;
        public UserRepository(PicPayContext context)
        {
            _context = context;
        }


        public void Create(User user)
        {
            _context.Set<User>().Add(user);

            _context.SaveChanges();
        }

        public bool DocumentAlreadyExists(DocumentID document)
        {
            var item = _context.Users.FirstOrDefault();
            return _context.Users.Any(x => x.DocumentID.Value == document.Value);
        }

        public bool EmailAlreadyExists(Email email)
        {
            return _context.Users.Any(x => x.Email.Value == email.Value);
        }

        public User? GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
