using Demarco.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demarco.Repository.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void UpDate(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");
    }
}
