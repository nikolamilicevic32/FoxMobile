using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fox.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly DbSet<T> _entities;
        private readonly DatabaseContext _context;

        public GenericRepository()
        {
            _context = new DatabaseContext();
            _entities = _context.Set<T>();
        }

        public async Task Add(T model)
        {
             _entities.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        public async Task Remove(T model)
        {
            _entities.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var result = await _entities.FindAsync(id);
            _entities.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAll()
        {
            _entities.RemoveRange(_entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T model)
        {
            _entities.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
