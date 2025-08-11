using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Core.Services
{
      public interface IService<T> where T : class
        {
            Task<T> GetByIdAsync(int id);
            Task<IEnumerable<T>> GetAllAsync();

            IQueryable<T> Where(Expression<Func<T, bool>> expression);

            Task<T> AddAsync(T entity);
            Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
            T Update(T entity);
            T Remove(T entity);
            Task<T> RemoveById(int id);
            IEnumerable<T> RemoveRange(IEnumerable<T> entities);

        }
    
}