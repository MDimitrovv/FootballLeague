namespace FootballLeague.Application.Exceptions;

public class InvalidAttendanceException : Exception
{
    public InvalidAttendanceException(int attendance, int capacity)
    : base($"Attendance ({attendance}) cannot be higher than stadium capacity ({capacity})!")
    {
    }
}