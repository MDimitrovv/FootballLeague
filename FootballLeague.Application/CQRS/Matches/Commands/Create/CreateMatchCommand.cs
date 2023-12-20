namespace FootballLeague.Application.CQRS.Matches.Commands.Create;

using MediatR;

public sealed record CreateMatchCommand(
    int HomeTeamId, 
    int HomeTeamGoals,
    int AwayTeamId, 
    int AwayTeamGoals, 
    int Attendance) : IRequest<Result>;