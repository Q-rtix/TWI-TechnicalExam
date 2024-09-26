using TreewInc.Core.Domain.Entities;

namespace TreewInc.Core.Abstractions;

public interface IUnitOfWork
{
	IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
	Task<int> SaveAsync(CancellationToken cancellationToken = default);
	int Save();
}
