namespace FootballLeague.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, int id)
        : base($"Entity '{name}' with Id '{id}' was not found.")
    {
    }
}