using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(long id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
    }
}