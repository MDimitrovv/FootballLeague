namespace FootballLeague.Application.CQRS.Teams.Commands.Edit;

using FluentValidation;

public class EditTeamCommandValidator : AbstractValidator<EditTeamCommand>
{
    public EditTeamCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.Name)
            .NotEmpty();
        
        RuleFor(x => x.StadiumName)
            .NotEmpty();
        
        RuleFor(x => x.Capacity).
            GreaterThan(0)
            .WithMessage("Stadium capacity cannot be a negative number!");
    }
}