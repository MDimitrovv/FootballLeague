namespace FootballLeague.Application.CQRS.Matches.Queries.AllMatches;

using Common;
using MediatR;

public record AllMatchesDetailsQuery : IRequest<IEnumerable<MatchDto>>;