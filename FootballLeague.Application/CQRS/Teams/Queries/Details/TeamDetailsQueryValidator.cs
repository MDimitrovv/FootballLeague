namespace FootballLeague.Application.CQRS.Teams.Queries.Details;

using FluentValidation;

public class TeamDetailsQueryValidator : AbstractValidator<TeamDetailsQuery>
{
    public TeamDetailsQueryValidator()
    {
        RuleFor(t => t.Id)
            .NotEmpty()
            .GreaterThanOrEqualTo(0);
    }
}