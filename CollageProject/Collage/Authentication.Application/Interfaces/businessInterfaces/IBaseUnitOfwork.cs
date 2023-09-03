using System.Linq.Expressions;

namespace Collage.Domain.Commons
{

    public interface IBaseBusiness<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> DeleteByIdAsync(object id);

        Task<IEnumerable<TEntity>> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);

        void Dispose();

        Task<IQueryable<TEntity>> ReadAllAsync();

        Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string include = "");

        Task<TEntity> ReadByIdAsync(object id);

        Task<string> SaveAsync();

        Task<TEntity> Update(TEntity entity);
    }
}
