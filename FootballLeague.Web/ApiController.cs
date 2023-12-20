namespace FootballLeague.Web;

using Application;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator? Mediator
        => _mediator ??= HttpContext
            .RequestServices
            .GetService<IMediator>();
    
    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
        => Mediator!.Send(request).ToActionResult();

    protected Task<ActionResult> Send(IRequest<Result> request)
        => Mediator!.Send(request).ToActionResult()!;

    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
        => Mediator!.Send(request).ToActionResult();
}