namespace FootballLeague.Domain.Models.Teams;

using Common;

public class Stadium : ValueObject
{
    internal Stadium(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
    }
    
    public string Name { get; set; }
    
    public int Capacity { get; set; }
}