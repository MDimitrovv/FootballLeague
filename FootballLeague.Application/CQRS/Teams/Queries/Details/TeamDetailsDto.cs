namespace FootballLeague.Application.CQRS.Teams.Queries.Details;

using AutoMapper;
using Common;
using Domain.Models.Teams;
using Mapping;

    public class TeamDetailsDto : IMapFrom<Team>
    {
        public int Id { get; init; }

        public string Name { get; init; } = default!;
        
        public string StadiumName { get; init; } = default!;

        public int StadiumCapacity { get; init; }

        public StatisticsDto Statistics { get; init; } = default!;

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Team, TeamDetailsDto>()
                .ForMember(t => t.StadiumName, src => src.MapFrom(t => t.Stadium.Name))
                .ForMember(t => t.StadiumCapacity, src => src.MapFrom(t => t.Stadium.Capacity))
                .ForMember(t => t.Statistics, src => src.MapFrom(t => t.Statistics));
    }

