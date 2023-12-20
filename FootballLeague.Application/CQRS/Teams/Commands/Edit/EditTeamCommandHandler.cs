namespace FootballLeague.Application.CQRS.Teams.Commands.Edit;

using MediatR;
using static Constants.ApplicationConstants;

public class EditTeamCommandHandler : IRequestHandler<EditTeamCommand, Result>
{
    private readonly ITeamRepository _teamRepository;

    public EditTeamCommandHandler(ITeamRepository teamRepository) => _teamRepository = teamRepository;
    
    public async Task<Result> Handle(EditTeamCommand request, CancellationToken cancellationToken)
    {
        var teamExists = await _teamRepository.TeamNameExists(request.Id, request.Name, cancellationToken);

        if (teamExists) return Result.Failure(new[] { string.Format(TeamNameExists, request.Name) });
        
        var teamToEdit = await _teamRepository.FindById(request.Id, cancellationToken);

        teamToEdit
            .UpdateName(request.Name)
            .UpdateStadium(request.StadiumName, request.Capacity);
        
        _teamRepository.Update(teamToEdit, cancellationToken);

         return await _teamRepository.Complete()
             ? Result.Success
             : Result.Failure(new[] { SomethingWentWrong });
    }
}