namespace FootballLeague.Web.Controllers;

using Application.CQRS.Matches.Commands.Create;
using Application.CQRS.Matches.Commands.Delete;
using Application.CQRS.Matches.Queries.AllMatches;
using Application.CQRS.Matches.Queries.Common;
using Application.CQRS.Matches.Queries.SingleMatch;
using Microsoft.AspNetCore.Mvc;

public class MatchController : ApiController
{
    [HttpGet]
    [Route(nameof(Details))]
    public async Task<ActionResult<MatchDto>> Details([FromQuery] SingleMatchDetailsQuery query)
        => await Send(query);

    [HttpGet]
    [Route(nameof(All))]
    public async Task<ActionResult<IEnumerable<MatchDto>>> All([FromQuery] AllMatchesDetailsQuery query)
        => await Send(query);
    
    [HttpPost]
    [Route(nameof(Create))]
    public async Task<ActionResult> Create(CreateMatchCommand command)
        => await Send(command);

    [HttpDelete] // we can use PUT or PATCH verb as we are only "soft" deleting the entity
    [Route(nameof(Delete))]
    public async Task<ActionResult> Delete(DeleteMatchCommand command)
        => await Send(command);
}