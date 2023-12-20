namespace FootballLeague.Application.CQRS.Teams.Queries.Ranking;

using MediatR;

public class TeamsRankingQueryHandler : IRequestHandler<TeamsRankingQuery, IEnumerable<TeamsRankingDto>>
{
    private readonly ITeamRepository _teamRepository;

    public TeamsRankingQueryHandler(ITeamRepository teamRepository) => _teamRepository = teamRepository;
    
    public async Task<IEnumerable<TeamsRankingDto>> Handle(TeamsRankingQuery request, CancellationToken cancellationToken)
        => await _teamRepository.GetTeamsRanked(cancellationToken);
}