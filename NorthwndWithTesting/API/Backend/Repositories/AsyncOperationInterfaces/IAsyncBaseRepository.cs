using System.Linq.Expressions;

namespace API.Backend.Repositories.AsyncOperationInterfaces
{
    public interface IAsyncBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> FindByExpresion(Expression<Func<TEntity, bool>> expression);
    }
}
