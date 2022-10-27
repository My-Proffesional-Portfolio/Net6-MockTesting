using API.Backend.Repositories.SyncOperationsInterfaces;
using API.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Backend.Repositories.AsyncOperationInterfaces
{
    public class AsyncBaseRepository<TEntity> : IAsyncBaseRepository<TEntity> where TEntity : class
    {
        private readonly NORTHWNDContext _dbContext;
        public AsyncBaseRepository(NORTHWNDContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual IQueryable<TEntity> FindByExpresion(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

       
    }
}
