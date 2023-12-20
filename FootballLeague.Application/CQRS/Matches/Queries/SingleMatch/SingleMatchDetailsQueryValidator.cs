namespace FootballLeague.Application.CQRS.Matches.Queries.SingleMatch;

using FluentValidation;

public class SingleMatchDetailsQueryValidator : AbstractValidator<SingleMatchDetailsQuery>
{
    public SingleMatchDetailsQueryValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty();
        
        RuleFor(m => m.Id)
            .GreaterThan(0)
            .WithMessage("Match id cannot be a negative number!");
    }
}