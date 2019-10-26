using System.Linq;
using System.Threading.Tasks;
using FamPix.Core;

namespace FamPix.Data.Abstracts
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> AddAsync(T photo);
        IQueryable<T> GetAll();
        Task<T> GetAsync(int id);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(T photo);
    }
}