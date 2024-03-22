using System.Linq.Expressions;

namespace BookLibrary.Domain.Core.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class, IEntity
	{
		TEntity Get(Expression<Func<TEntity, bool>> expression);
		Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
		IEnumerable<TEntity> GetAll();
		Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
		IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
		Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
	}
}