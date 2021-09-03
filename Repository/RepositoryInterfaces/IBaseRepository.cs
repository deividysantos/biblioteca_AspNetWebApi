using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace biblioteca_AspNetWebApi.Repository.RepositoryInterfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}