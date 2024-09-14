using System.Linq.Expressions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Abstractions;

public interface IRepository<TEntity> where TEntity : Entity
{
	IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>>[]? filters = null, bool asNoTracking = false, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
	Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>[] filters, bool asNoTracking = false, CancellationToken cancellationToken = default);
	Task AddOneAsync(TEntity entity, CancellationToken cancellationToken = default);
	void UpdateOne(TEntity entity);
	void RemoveOne(TEntity entity);
}
