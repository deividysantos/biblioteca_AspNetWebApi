using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Data;
using biblioteca_AspNetWebApi.Models;
using biblioteca_AspNetWebApi.Repository.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_AspNetWebApi.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BibliotecaContext _context;

        public BaseRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(T entity, Guid id)
        {
            entity.Id = id;
            var verify = await GetByIdAsync(entity.Id);

            if(verify is null) return false;

            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if(entity is null) return false;
            
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> Inactivate (Guid id) 
        {
            var entity = await GetByIdAsync(id);

            entity.IsInactivated = true;

            _context.Update(entity);
            return _context.SaveChanges() == 1;
        }
    }
}