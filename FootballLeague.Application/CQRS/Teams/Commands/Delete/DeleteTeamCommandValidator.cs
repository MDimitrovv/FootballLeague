namespace FootballLeague.Application.CQRS.Teams.Commands.Delete;

using FluentValidation;

public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
{
    public DeleteTeamCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotEmpty();
        
        RuleFor(t => t.Id)
            .GreaterThan(0)
            .WithMessage("Team Id cannot be a negative number!");
    }
}