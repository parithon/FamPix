using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamPix.Core;

namespace FamPix.Data.Abstracts
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        IQueryable<T> GetAll();
        Task<T> GetAsync(int id);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(T entity);
    }
}