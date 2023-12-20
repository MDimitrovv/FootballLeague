namespace FootballLeague.Application.CQRS.Teams.Commands.Delete;

using MediatR;
using static Constants.ApplicationConstants;

public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, Result>
{
    private readonly ITeamRepository _teamRepository;

    public DeleteTeamCommandHandler(ITeamRepository teamRepository) => _teamRepository = teamRepository;
    
    public async Task<Result> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        var teamToDelete = await _teamRepository.FindById(request.Id, cancellationToken);
        
        teamToDelete.DeleteTeam();
        
        _teamRepository.Update(teamToDelete, cancellationToken);

        return await _teamRepository.Complete() 
            ? Result.Success 
            : Result.Failure(new []{ SomethingWentWrong });
    }
}