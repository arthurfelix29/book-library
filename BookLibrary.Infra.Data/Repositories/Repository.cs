using BookLibrary.Domain.Core.Interfaces;
using BookLibrary.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookLibrary.Infra.Data.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
	{
		protected readonly BookLibraryContext _dbContext;
		protected readonly DbSet<TEntity> _entitySet;

		public Repository(BookLibraryContext dbContext)
		{
			_dbContext = dbContext;
			_entitySet = _dbContext.Set<TEntity>();
		}

		public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
		{
			return _entitySet.FirstOrDefault(expression);
		}

		public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
		{
			return await _entitySet.FirstOrDefaultAsync(expression, cancellationToken);
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return _entitySet.AsEnumerable();
		}

		public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
		{
			return _entitySet.Where(expression).AsEnumerable();
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _entitySet.ToListAsync(cancellationToken);
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
		{
			return await _entitySet.Where(expression).ToListAsync(cancellationToken);
		}
	}
}