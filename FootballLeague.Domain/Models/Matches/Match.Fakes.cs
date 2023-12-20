namespace FootballLeague.Domain.Models.Matches;

using static Teams.TeamFakes;

public static class MatchFakes
{
    public static Match GenerateFakeMatch()
        => new (GenerateFakeTeam(), 1, GenerateFakeAwayTeam(), 1, 3500);
}