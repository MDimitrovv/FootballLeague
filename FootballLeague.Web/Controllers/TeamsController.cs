namespace FootballLeague.Web.Controllers;

using Application.CQRS.Teams.Commands.Create;
using Application.CQRS.Teams.Commands.Delete;
using Application.CQRS.Teams.Commands.Edit;
using Application.CQRS.Teams.Queries.Details;
using Application.CQRS.Teams.Queries.Ranking;
using Microsoft.AspNetCore.Mvc;

public class TeamsController : ApiController
{
    [HttpGet]
    [Route(nameof(Details))]
    public async Task<ActionResult<TeamDetailsDto>> Details([FromQuery] TeamDetailsQuery query)
        => await Send(query);
    
    [HttpGet]
    [Route(nameof(Ranking))]
    public async Task<ActionResult<IEnumerable<TeamsRankingDto>>> Ranking([FromQuery] TeamsRankingQuery query)
        => await Send(query);
    
    [HttpPost]
    [Route(nameof(Create))]
    public async Task<ActionResult> Create(CreateTeamCommand command)
        => await Send(command);

    [HttpPut]
    [Route(nameof(Edit))]
    public async Task<ActionResult> Edit(EditTeamCommand command)
        => await Send(command);

    [HttpDelete] // we can use PUT or PATCH verb as we are only soft deleting the entity
    [Route(nameof(Delete))]
    public async Task<ActionResult> Delete(DeleteTeamCommand command)
        => await Send(command);
}