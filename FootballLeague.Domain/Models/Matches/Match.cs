namespace FootballLeague.Domain.Models.Matches;

using Common;
using Teams;

public class Match : Entity<int>, IAggregateRoot
{
    internal Match(Team homeTeam, int homeTeamGoals, Team awayTeam, int awayTeamGoals, int attendance)
    {
        HomeTeam = homeTeam;
        HomeTeamGoals = homeTeamGoals;
        AwayTeam = awayTeam;
        AwayTeamGoals = awayTeamGoals;
        Attendance = attendance;
    }

    // Private constructors for Entity Framework Core to use
    private Match(int homeTeamGoals, int awayTeamGoals, int attendance)
    {
        HomeTeamGoals = homeTeamGoals;
        AwayTeamGoals = awayTeamGoals;
        Attendance = attendance;
        HomeTeam = default!;
        AwayTeam = default!;
    }

    public Team HomeTeam { get; set; }
    
    public int HomeTeamId { get; set; }
    
    public int HomeTeamGoals { get; }

    public Team AwayTeam { get; set; }

    public int AwayTeamId { get; set; }
    
    public int AwayTeamGoals { get; set; }
    
    public int Attendance { get; set; }

    public bool IsDeleted { get; private set; }

    public void DeleteMatch() => IsDeleted = true;
}