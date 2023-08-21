using PicPayBackEnd.Domain.Entities;

namespace PicPayBackEnd.Data.Repositories
{
    public interface IPayerRepository
    {
        void Create(Payer payer);
    }
}
