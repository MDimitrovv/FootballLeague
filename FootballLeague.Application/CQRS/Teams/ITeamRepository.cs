namespace FootballLeague.Application.CQRS.Teams;

using Contracts;
using Domain.Models.Teams;
using Queries.Details;
using Queries.Ranking;

public interface ITeamRepository : IRepository<Team>
{
    Task<Team> FindById(int id, CancellationToken cancellationToken);

    Task<bool> TeamNameExists(int? id, string name, CancellationToken cancellationToken);

    Task<TeamDetailsDto> GetDetails(int id, CancellationToken cancellationToken);

    Task<IEnumerable<TeamsRankingDto>> GetTeamsRanked(CancellationToken cancellationToken);

    Task<(Team homeTeam, Team awayTeam)> GetPlayingTeams(int homeTeamId, int awayTeamId, CancellationToken cancellationToken);
}