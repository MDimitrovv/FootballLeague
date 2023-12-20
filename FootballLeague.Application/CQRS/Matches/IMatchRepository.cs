namespace FootballLeague.Application.CQRS.Matches;

using Contracts;
using Domain.Models.Matches;
using Queries.Common;

public interface IMatchRepository : IRepository<Match>
{
    Task<Match> FindById(int id, CancellationToken cancellationToken);

    Task<MatchDto> SingleMatchDetails(int id, CancellationToken cancellationToken);

    Task<IEnumerable<MatchDto>> AllMatches(CancellationToken cancellationToken);
}