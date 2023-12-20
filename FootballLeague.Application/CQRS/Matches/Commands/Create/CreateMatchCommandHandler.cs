namespace FootballLeague.Application.CQRS.Matches.Commands.Create;

using Domain.Factories.Matches;
using Domain.Models.Matches;
using Exceptions;
using MediatR;
using Teams;
using static Constants.ApplicationConstants;

public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, Result>
{
    private readonly IMatchFactory _matchFactory;
    private readonly IMatchRepository _matchRepository;
    private readonly ITeamRepository _teamRepository;

    public CreateMatchCommandHandler(IMatchFactory matchFactory, IMatchRepository matchRepository, ITeamRepository teamRepository)
    {
        _matchFactory = matchFactory;
        _matchRepository = matchRepository;
        _teamRepository = teamRepository;
    }

    public async Task<Result> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
    {
        var (homeTeam, awayTeam) = await _teamRepository
            .GetPlayingTeams(request.HomeTeamId, request.AwayTeamId, cancellationToken);
        
        var match = _matchFactory
            .WithHomeTeam(homeTeam)
            .WithHomeTeamGoals(request.HomeTeamGoals)
            .WithAwayTeam(awayTeam)
            .WithAwayTeamGoals(request.AwayTeamGoals)
            .WithAttendance(request.Attendance)
            .Build();

        await _matchRepository.AddAsync(match, cancellationToken);

        UpdateTeamStatistics(match);
        
        // We could use SignalR Hub to notify client that there are changes in ranking table

        return await _matchRepository.Complete()
            ? Result.Success
            : Result.Failure(new[] { SomethingWentWrong });
    }

    private void UpdateTeamStatistics(Match match)
    {
        var stadiumCapacity = match.HomeTeam.Stadium.Capacity;
        var attendance = match.Attendance;
        
        if (stadiumCapacity < attendance) throw new InvalidAttendanceException(attendance, stadiumCapacity);
        
        match.HomeTeam.Statistics.UpdateStatistics(match.HomeTeamGoals, match.AwayTeamGoals);
        match.AwayTeam.Statistics.UpdateStatistics(match.AwayTeamGoals, match.HomeTeamGoals);
    }
}