namespace FootballLeague.Domain.Models.Teams;

using Common;

public class Team : Entity<int>, IAggregateRoot
{
    internal Team(string name, string stadiumName, int stadiumCapacity)
    {
        Name = name;
        Stadium = new Stadium(stadiumName, stadiumCapacity);
        Statistics = new Statistics();
    }

    // Private constructor for Entity Framework to use
    private Team(string name)
    {
        Name = name;
        Stadium = default!;
        Statistics = default!;
    }
    
    public string Name { get; private set; }
    
    public Stadium Stadium { get; set; }

    public Statistics Statistics { get; private set; }

    public bool IsDeleted { get; private set; }
    
    public Team UpdateName(string name)
    {
        Name = name;
        return this;
    }

    public Team UpdateStadium(string stadiumName, int capacity)
    {
        Stadium.Name = stadiumName;
        Stadium.Capacity = capacity;
        return this;
    }

    public void DeleteTeam() => IsDeleted = true;
}