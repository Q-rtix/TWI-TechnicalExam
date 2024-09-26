using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;
using TreewInc.Core.Infrastructure.Repositories;
using TreewInc.Core.Persistence.Contexts;

namespace TreewInc.Core.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
	private readonly AppDbContext _context;
	private readonly Dictionary<string, object> _repositories;

	public UnitOfWork(AppDbContext context)
	{
		_context = context;
		_repositories = new Dictionary<string, object>();
	}

	public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
	{
		var entityType = typeof(TEntity);

		if (_repositories.TryGetValue(entityType.Name, out var repository))
			return (IRepository<TEntity>)repository;

		var repoType = typeof(Repository<>).MakeGenericType(entityType);
		var repo = Activator.CreateInstance(repoType, _context);

		if (repo != null)
			_repositories.Add(entityType.Name, repo);

		return (IRepository<TEntity>)_repositories[entityType.Name];
	}

	public Task<int> SaveAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);

	public int Save() => _context.SaveChanges();
}
