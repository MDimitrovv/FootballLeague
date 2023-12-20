namespace FootballLeague.Domain.Factories.Teams;

using Models.Teams;

internal class TeamFactory : ITeamFactory
{
    private string _teamName = default!;
    private string _teamStadiumName = default!;
    private int _teamStadiumCapacity;
    
    public ITeamFactory WithName(string name)
    {
        _teamName = name.Trim();
        return this;
    }

    public ITeamFactory WithStadium(string stadiumName, int stadiumCapacity)
    {
        _teamStadiumName = stadiumName.Trim();
        _teamStadiumCapacity = stadiumCapacity;
        return this;
    }

    public Team Build() => new(_teamName, _teamStadiumName, _teamStadiumCapacity);
}