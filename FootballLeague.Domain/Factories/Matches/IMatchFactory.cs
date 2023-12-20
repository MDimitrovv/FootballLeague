namespace FootballLeague.Domain.Factories.Matches;

using Models.Matches;
using Models.Teams;

public interface IMatchFactory : IFactory<Match>
{
    IMatchFactory WithHomeTeam(Team homeTeam);
    
    IMatchFactory WithHomeTeamGoals(int goals);

    IMatchFactory WithAwayTeam(Team awayTeam);
    
    IMatchFactory WithAwayTeamGoals(int goals);
    
    IMatchFactory WithAttendance(int spectators);
}