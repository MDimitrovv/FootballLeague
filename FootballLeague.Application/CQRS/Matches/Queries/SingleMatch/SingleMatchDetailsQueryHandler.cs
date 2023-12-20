namespace FootballLeague.Application.CQRS.Matches.Queries.SingleMatch;

using Common;
using MediatR;

public class SingleMatchDetailsQueryHandler : IRequestHandler<SingleMatchDetailsQuery, MatchDto>
{
    private readonly IMatchRepository _matchRepository;

    public SingleMatchDetailsQueryHandler(IMatchRepository matchRepository) => _matchRepository = matchRepository;
    
    public async Task<MatchDto> Handle(SingleMatchDetailsQuery request, CancellationToken cancellationToken)
        => await _matchRepository.SingleMatchDetails(request.Id, cancellationToken);
}