namespace FootballLeague.Application.CQRS.Teams.Queries.Common;

using AutoMapper;
using Mapping;
using FootballLeague.Domain.Models.Teams;

public class StatisticsDto : IMapFrom<Statistics>
{
    public int Points { get; init; }

    public int MatchesPlayed { get; init; }

    public int Wins { get; init; }
    
    public int Draws { get; init; }
    
    public int Losses { get; init; }
    
    public int GoalsFor { get; init; }

    public int GoalsAgainst { get; init; }

    public int GoalsDifference { get; init; }

    public void Mapping(Profile mapper)
        => mapper
            .CreateMap<Statistics, StatisticsDto>()
            .ForMember(x => x.GoalsDifference, cfg => cfg.MapFrom(s => s.GoalsFor - s.GoalsAgainst));
}