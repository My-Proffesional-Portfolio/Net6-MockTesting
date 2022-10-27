using System.Linq.Expressions;

namespace API.Backend.Repositories.SyncOperationsInterfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> FindByExpresion(Expression<Func<TEntity, bool>> expression);

    }
}
