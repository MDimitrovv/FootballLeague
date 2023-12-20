namespace FootballLeague.Application.CQRS.Matches.Commands.Delete;

using MediatR;

public sealed record DeleteMatchCommand(int Id) : IRequest<Result>;