namespace FootballLeague.Application.CQRS.Teams.Queries.Details;

using MediatR;

public class TeamDetailsQueryHandler : IRequestHandler<TeamDetailsQuery, TeamDetailsDto>
{
    private readonly ITeamRepository _teamRepository;

    public TeamDetailsQueryHandler(ITeamRepository teamRepository) =>  _teamRepository = teamRepository;

    public async Task<TeamDetailsDto> Handle(TeamDetailsQuery request, CancellationToken cancellationToken) 
        => await _teamRepository.GetDetails(request.Id, cancellationToken);

}