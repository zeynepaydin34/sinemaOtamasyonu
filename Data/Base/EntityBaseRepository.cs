using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using sinemaOtamasyonu.Models;
using System.Linq.Expressions;

namespace sinemaOtamasyonu.Data.Base
{
    //interface ve repositorylerin yazılmasıhttps://www.youtube.com/watch?v=MleB4lXLxo4&list=RDCMUCbkbOlw8snP93RJ2BhH44Qw&index=4
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        private readonly AppDbContext _context;
        public EntityBaseRepository(AppDbContext context)
        {
           _context= context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteAsync(int id)
        {
            var entity= await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State=EntityState.Modified;

            await _context.SaveChangesAsync();

        }
    }
}
