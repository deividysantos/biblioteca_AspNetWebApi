using System.Collections.Generic;
using System.Threading.Tasks;

namespace biblioteca_AspNetWebApi.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity, int id);
        Task<bool> DeleteAsync(int id);
    }
}