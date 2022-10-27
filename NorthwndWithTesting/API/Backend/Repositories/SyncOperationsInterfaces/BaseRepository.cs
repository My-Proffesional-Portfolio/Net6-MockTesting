using API.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Backend.Repositories.SyncOperationsInterfaces
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly NORTHWNDContext _dbContext;
        public BaseRepository(NORTHWNDContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual void Add(TEntity entity)
        {
            _dbContext.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
        }

        public virtual IQueryable<TEntity> FindByExpresion(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }
    }
}
