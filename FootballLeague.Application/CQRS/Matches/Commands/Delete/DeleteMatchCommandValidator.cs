namespace FootballLeague.Application.CQRS.Matches.Commands.Delete;

using FluentValidation;

public class DeleteMatchCommandValidator : AbstractValidator<DeleteMatchCommand>
{
    public DeleteMatchCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty();
    }
}