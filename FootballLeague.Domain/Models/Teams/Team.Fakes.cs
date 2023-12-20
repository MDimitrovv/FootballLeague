namespace FootballLeague.Domain.Models.Teams;

public static class TeamFakes
{
    public static Team GenerateFakeTeam() 
        => new ("Barcelona", "Camp Nou", 99354);
    
    public static Team GenerateFakeAwayTeam()
        => new ("Liverpool", "Anfield", 57158);
}