namespace FootballLeague.Application.Contracts;

using Domain.Common;

// aggregate roots only, restrict the access of the non-domain layers
public interface IRepository<TEntity> 
    where TEntity : IAggregateRoot
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    void Update(TEntity entity, CancellationToken cancellationToken = default);

    Task<bool> Complete();
}