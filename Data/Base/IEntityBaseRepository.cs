using sinemaOtamasyonu.Models;
using System.Linq.Expressions;

namespace sinemaOtamasyonu.Data.Base
{
    ////interface ve repositorylerin yazılmasıhttps://www.youtube.com/watch?v=MleB4lXLxo4&list=RDCMUCbkbOlw8snP93RJ2BhH44Qw&index=4
    public interface IEntityBaseRepository<T> where T : class,  IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T,object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity );
        Task DeleteAsync(int id);
    }
}
