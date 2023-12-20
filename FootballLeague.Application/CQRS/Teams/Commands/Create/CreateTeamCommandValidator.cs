namespace FootballLeague.Application.CQRS.Teams.Commands.Create;

using FluentValidation;

public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        
        RuleFor(x => x.StadiumName)
            .NotEmpty();
        
        RuleFor(x => x.Capacity)
            .GreaterThan(0)
            .WithMessage("Stadium capacity cannot be a negative number!");
    }
}

