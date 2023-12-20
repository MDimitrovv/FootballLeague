namespace FootballLeague.Application.CQRS.Teams.Queries.Ranking;

using MediatR;

public sealed record TeamsRankingQuery : IRequest<IEnumerable<TeamsRankingDto>>;