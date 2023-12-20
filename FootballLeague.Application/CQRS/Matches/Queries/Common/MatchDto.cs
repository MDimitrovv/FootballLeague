namespace FootballLeague.Application.CQRS.Matches.Queries.Common;

using AutoMapper;
using Mapping;
using FootballLeague.Domain.Models.Matches;

public class MatchDto : IMapFrom<Match>
{
    public string HomeTeamName { get; init; } = default!;

    public int HomeTeamGoals { get; init; }

    public string AwayTeamName { get; init; } = default!;
    
    public int AwayTeamGoals { get; init; }

    public string Venue { get; init; } = default!;

    public int Attendance { get; init; }

    public void Mapping(Profile mapper)
        => mapper.CreateMap<Match, MatchDto>()
            .ForMember(m => m.HomeTeamName, cfg => cfg.MapFrom(x => x.HomeTeam.Name))
            .ForMember(m => m.AwayTeamName, cfg => cfg.MapFrom(x => x.AwayTeam.Name))
            .ForMember(m => m.Venue, cfg => cfg.MapFrom(x => x.HomeTeam.Stadium.Name));
}