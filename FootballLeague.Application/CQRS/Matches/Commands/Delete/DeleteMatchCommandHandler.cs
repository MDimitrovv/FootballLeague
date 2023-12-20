namespace FootballLeague.Application.CQRS.Matches.Commands.Delete;

using MediatR;
using static Constants.ApplicationConstants;

public class DeleteMatchCommandHandler : IRequestHandler<DeleteMatchCommand, Result>
{
    private readonly IMatchRepository _matchRepository;

    public DeleteMatchCommandHandler(IMatchRepository matchRepository) => _matchRepository = matchRepository;
    
    public async Task<Result> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
    {
        var matchToDelete = await _matchRepository.FindById(request.Id, cancellationToken);
        
        matchToDelete.DeleteMatch();
        
        _matchRepository.Update(matchToDelete, cancellationToken);

        return await _matchRepository.Complete()
            ? Result.Success
            : Result.Failure(new[] { SomethingWentWrong });
    }
}