namespace FootballLeague.Application.CQRS.Teams.Queries.Details;

using MediatR;

public sealed record TeamDetailsQuery(int Id) : IRequest<TeamDetailsDto>;