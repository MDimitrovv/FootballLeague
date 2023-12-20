namespace FootballLeague.Application.CQRS.Teams.Commands.Create;

using MediatR;

public sealed record CreateTeamCommand(string Name, string StadiumName, int Capacity) : IRequest<Result>;