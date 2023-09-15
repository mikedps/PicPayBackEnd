using Microsoft.EntityFrameworkCore;
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


        public async Task<Guid> CreateAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);

            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> DocumentAlreadyExistsAsync(DocumentID document)
        {
            return await _context.Users.AnyAsync(x => x.DocumentID.Value == document.Value);
        }

        public async Task<bool> EmailAlreadyExistsAsync(Email email)
        {
            return await _context.Users.AnyAsync(x => x.Email.Value == email.Value);
        }



      /*  public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(x => new UserDTO
            {
                DocumentID = x.DocumentID.Value,
                ID = x.Id,
                Email = x.Email.Value,
                Name = x.Name,
                Surname = x.Surname,
                UserType = x.UserType
            }).Take(30)
            .ToListAsync();
        }
      */

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}
