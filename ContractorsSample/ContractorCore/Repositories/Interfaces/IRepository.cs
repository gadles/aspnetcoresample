using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractorCore.Repositories.Interfaces
{
    public interface IRepository<TObject, in TPrimarykey>
    {
        ICollection<TObject> GetAll();
        Task<ICollection<TObject>> GetAllAsync();
        TObject GetById(TPrimarykey id);
        Task<TObject> GetByIdAsync(TPrimarykey id);
        bool Create(TObject entity);
        bool Update(TObject entity);
        bool Delete(TPrimarykey id);
        int Save();
    }
}
