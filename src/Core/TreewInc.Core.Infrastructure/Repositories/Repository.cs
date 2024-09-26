using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;
using TreewInc.Core.Persistence.Contexts;

namespace TreewInc.Core.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
	private readonly DbSet<TEntity> _dbSet;

	public Repository(AppDbContext context) => _dbSet = context.Set<TEntity>();

	public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>>[]? filters = null, bool asNoTracking = false, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
	{
		IQueryable<TEntity> query = _dbSet;

		if (asNoTracking)
			query = query.AsNoTracking();
		if (filters is not null)
			query = filters.Aggregate(query, (current, filter) => current.Where(filter));
		if (orderBy is not null)
			query = orderBy(query);

		return query;
	}

	public Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>[] filters, bool asNoTracking = false, CancellationToken cancellationToken = default)
	{
		IQueryable<TEntity> query = _dbSet;

		if (asNoTracking)
			query = query.AsNoTracking();

		query = filters.Aggregate(query, (current, filter) => current.Where(filter));

		return query.FirstOrDefaultAsync(cancellationToken);
	}

	public Task AddOneAsync(TEntity entity, CancellationToken cancellationToken = default)
		=> _dbSet.AddAsync(entity, cancellationToken).AsTask();

	public void UpdateOne(TEntity entity)
		=> _dbSet.Update(entity);

	public void RemoveOne(TEntity entity)
		=> _dbSet.Remove(entity);
}
