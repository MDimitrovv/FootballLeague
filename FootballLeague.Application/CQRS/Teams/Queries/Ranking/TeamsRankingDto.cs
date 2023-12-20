namespace FootballLeague.Application.CQRS.Teams.Queries.Ranking;

using Common;
using Details;
using Mapping;
using FootballLeague.Domain.Models.Teams;

public class TeamsRankingDto : IMapFrom<Team>
{
    public string Name { get; set; } = default!;

    public StatisticsDto Statistics { get; set; } = default!;
}