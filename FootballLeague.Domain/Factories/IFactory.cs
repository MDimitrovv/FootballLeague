namespace FootballLeague.Domain.Factories;

using Common;

// factories should work only with Aggregate roots
public interface IFactory<out TEntity>
    where TEntity : IAggregateRoot
{
    TEntity Build();
}