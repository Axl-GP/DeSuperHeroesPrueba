using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Implementations
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().FirstOrDefaultAsync(predicate);
        

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
     

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);
        

        public void Remove(T entity) => _context.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);

        public async Task<IEnumerable<T>> ToListAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>()
            .Where(predicate).ToListAsync();
    }
}
