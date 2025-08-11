using Microsoft.EntityFrameworkCore;
using MulakatAPI.Core.Repositories;
using MulakatAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        IGenericRepository<T> repository;

        public Service(IGenericRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await repository.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await repository.AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public T Remove(T entity)
        {
            repository.Remove(entity);
            return entity;
        }
        public async Task<T> RemoveById(int id)
        {
            T entity=await repository.GetByIdAsync(id);
            repository.Remove(entity);
            return entity;
        }

        public IEnumerable<T> RemoveRange(IEnumerable<T> entities)
        {
            repository.RemoveRange(entities);
            return entities;
        }

        public T Update(T entity)
        {
           repository.Update(entity);
            return entity;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return repository.Where(expression);    
        }
    }
}
