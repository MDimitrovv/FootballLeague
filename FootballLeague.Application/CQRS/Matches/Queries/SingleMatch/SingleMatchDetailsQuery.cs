namespace FootballLeague.Application.CQRS.Matches.Queries.SingleMatch;

using Common;
using MediatR;

public sealed record SingleMatchDetailsQuery(int Id) : IRequest<MatchDto>;