using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.ValueObjects;

namespace PicPayBackEnd.Data.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task<User?> GetByIdAsync(Guid id);


        Task<bool> DocumentAlreadyExistsAsync(DocumentID document);

        Task<bool> EmailAlreadyExistsAsync(Email email);
    }
}
