namespace FootballLeague.Application.CQRS.Teams.Commands.Delete;

using MediatR;

public sealed record DeleteTeamCommand(int Id) : IRequest<Result>;