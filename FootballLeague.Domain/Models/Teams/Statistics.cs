namespace FootballLeague.Domain.Models.Teams;

using Common;

public class Statistics : ValueObject
{
    public int Points { get; private set; }

    public int MatchesPlayed { get; private set; }

    public int Wins { get; private set; }
    
    public int Draws { get; private set; }
    
    public int Losses { get; private set; }
    
    public int GoalsFor { get; private set; }

    public int GoalsAgainst { get; private set; }

    public void UpdateStatistics(int goalsFor, int goalsAgainst)
    {
        GoalsFor += goalsFor;
        GoalsAgainst += goalsAgainst;
        MatchesPlayed++;
        
        var goalDifference = goalsFor - goalsAgainst;

        switch (Math.Sign(goalDifference))
        {
            case 1:
                Wins++;
                Points += 3;
                break;
            case 0:
                Draws++;
                Points += 1;
                break;
            case -1:
                Losses++;
                break;
        }
    }
}