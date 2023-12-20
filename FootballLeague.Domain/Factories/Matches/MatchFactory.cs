namespace FootballLeague.Domain.Factories.Matches;

using Models.Matches;
using Models.Teams;

internal class MatchFactory : IMatchFactory
{
    private int _homeTeamGoals;
    private Team _homeTeam = default!;
    private Team _awayTeam = default!;
    private int _awayTeamGoals;
    private int _attendance;

    public IMatchFactory WithHomeTeam(Team homeTeam)
    {
        _homeTeam = homeTeam;
        return this;
    }
    
    public IMatchFactory WithHomeTeamGoals(int goals)
    {
        _homeTeamGoals = goals;
        return this;
    }
    
    public IMatchFactory WithAwayTeam(Team awayTeam)
    {
        _awayTeam = awayTeam;
        return this;
    }

    public IMatchFactory WithAwayTeamGoals(int goals)
    {
        _awayTeamGoals = goals;
        return this;
    }

    public IMatchFactory WithAttendance(int spectators)
    {
        _attendance = spectators;
        return this;
    }

    public Match Build() => new (_homeTeam, _homeTeamGoals, _awayTeam, _awayTeamGoals, _attendance);
}