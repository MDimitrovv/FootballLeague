namespace FootballLeague.Application.CQRS.Matches.Queries.AllMatches;

using Common;
using MediatR;

public class AllMatchesDetailsQueryHandler : IRequestHandler<AllMatchesDetailsQuery, IEnumerable<MatchDto>>
{
    private readonly IMatchRepository _matchRepository;

    public AllMatchesDetailsQueryHandler(IMatchRepository matchRepository) => _matchRepository = matchRepository;
    
    public async Task<IEnumerable<MatchDto>> Handle(AllMatchesDetailsQuery request, CancellationToken cancellationToken)
        => await _matchRepository.AllMatches(cancellationToken);
}