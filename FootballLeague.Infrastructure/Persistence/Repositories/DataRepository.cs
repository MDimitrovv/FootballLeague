namespace FootballLeague.Infrastructure.Persistence.Repositories;

using Application.Contracts;
using Domain.Common;

internal abstract class DataRepository<TEntity> : IRepository<TEntity>
  where TEntity: class, IAggregateRoot
{
  protected DataRepository(FootballLeagueDbContext db) => Data = db;
  
  protected FootballLeagueDbContext Data { get; }
  
  protected IQueryable<TEntity> All() => Data.Set<TEntity>();
  
  public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) 
    => await Data.AddAsync(entity, cancellationToken);
  
  public void Update(TEntity entity, CancellationToken cancellationToken = default) => Data.Update(entity); 
  
  public async Task<bool> Complete() => await Data.SaveChangesAsync() > 0;
}