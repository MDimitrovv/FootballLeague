namespace FootballLeague.Domain.Factories.Teams;

using Models.Teams;

public interface ITeamFactory : IFactory<Team>
{
    ITeamFactory WithName(string name);

    ITeamFactory WithStadium(string stadiumName, int capacity);
}