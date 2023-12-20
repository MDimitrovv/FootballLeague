namespace FootballLeague.Application.CQRS.Teams.Commands.Edit;

using MediatR;

public sealed record EditTeamCommand(int Id, string Name, string StadiumName, int Capacity) : IRequest<Result>;