namespace FootballLeague.Application.CQRS.Matches.Commands.Create;

using FluentValidation;

public class CreateMatchCommandValidator : AbstractValidator<CreateMatchCommand>
{
    public CreateMatchCommandValidator()
    {
        RuleFor(m => m.HomeTeamGoals)
            .GreaterThanOrEqualTo(0)
            .WithMessage("You cannot set negative home goals!");
        
        RuleFor(m => m.AwayTeamGoals)
            .GreaterThanOrEqualTo(0)
            .WithMessage("You cannot set negative away goals!");
        
        RuleFor(m => m.HomeTeamId)
            .GreaterThan(0)
            .WithMessage("Home team Id cannot be a negative value!");
        
        RuleFor(m => m.AwayTeamId)
            .GreaterThan(0)
            .WithMessage("Away team Id cannot be a negative value!");

        RuleFor(m => m.HomeTeamId)
            .NotEqual(x => x.AwayTeamId)
            .WithMessage("Home and away team cannot be the same!");

        RuleFor(m => m.Attendance)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Attendance cannot be a negative value!");
    }
}