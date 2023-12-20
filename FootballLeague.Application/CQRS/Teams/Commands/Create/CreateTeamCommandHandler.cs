namespace FootballLeague.Application.CQRS.Teams.Commands.Create;

using FootballLeague.Domain.Factories.Teams;
using MediatR;
using static Constants.ApplicationConstants;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Result>
{
    private readonly ITeamFactory _teamFactory;
    private readonly ITeamRepository _teamRepository;

    public CreateTeamCommandHandler(ITeamFactory teamFactory, ITeamRepository teamRepository)
    {
        _teamFactory = teamFactory;
        _teamRepository = teamRepository;
    }


    public async Task<Result> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var teamExists = await _teamRepository.TeamNameExists(null, request.Name, cancellationToken);

        if (teamExists) return Result.Failure(new[] { string.Format(TeamNameExists, request.Name) });
        
        var team = _teamFactory
            .WithName(request.Name)
            .WithStadium(request.StadiumName, request.Capacity)
            .Build();
        
        await _teamRepository.AddAsync(team, cancellationToken);

        return await _teamRepository.Complete() 
            ? Result.Success 
            : Result.Failure(new[] { SomethingWentWrong });
    }
}