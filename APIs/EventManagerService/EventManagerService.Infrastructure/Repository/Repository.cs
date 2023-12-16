using EventManagerService.Application.Interfaces;
using EventManagerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EventManagerService.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly EventManagerDbContext _dbContext;
        
        internal DbSet<T> dbSet;

        public Repository(EventManagerDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async virtual Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        public virtual T Get(Func<T, bool> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }

        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual IEnumerable<T> Where(Func<T, bool> filter)
        {
            return dbSet.Where(filter);
        }
    }
}
