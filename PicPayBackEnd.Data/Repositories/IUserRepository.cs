using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.ValueObjects;

namespace PicPayBackEnd.Data.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);

        User? GetById(Guid id); 

        bool DocumentAlreadyExists(DocumentID document);

        bool EmailAlreadyExists(Email email);
    }
}
