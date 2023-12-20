namespace FootballLeague.Infrastructure.Persistence.Repositories;

using Application.CQRS.Teams;
using Application.CQRS.Teams.Queries.Details;
using Application.CQRS.Teams.Queries.Ranking;
using Application.Exceptions;
using AutoMapper;
using Domain.Models.Teams;
using Microsoft.EntityFrameworkCore;

internal class TeamRepository : DataRepository<Team>, ITeamRepository
{
    private readonly IMapper _mapper;

    public TeamRepository(FootballLeagueDbContext db, IMapper mapper)
        : base(db)
        => _mapper = mapper;

    public async Task<Team> FindById(int id, CancellationToken cancellationToken)
        => await All()
               .FirstOrDefaultAsync(t => t.Id == id, cancellationToken)
           ?? throw new NotFoundException(nameof(Team), id);

    public async Task<bool> TeamNameExists(int? id, string name, CancellationToken cancellationToken) 
        => await All()
            .AnyAsync(t => t.Id != id && t.Name == name.Trim(), cancellationToken);
    
    public async Task<TeamDetailsDto> GetDetails(int id, CancellationToken cancellationToken)
        => await _mapper
               .ProjectTo<TeamDetailsDto>(All().Where(x => x.Id == id))
               .FirstOrDefaultAsync(cancellationToken)
           ?? throw new NotFoundException(nameof(Team), id);
    
    public async Task<IEnumerable<TeamsRankingDto>> GetTeamsRanked(CancellationToken cancellationToken)
    => (await _mapper
            .ProjectTo<TeamsRankingDto>(All())
            .ToListAsync(cancellationToken))
            .OrderByDescending(t => t.Statistics.Points)
            .ThenByDescending(t => t.Statistics.GoalsFor);

    public async Task<(Team homeTeam, Team awayTeam)> GetPlayingTeams(int homeTeamId, int awayTeamId, CancellationToken cancellationToken)
    {
        var teams = await All()
            .Where(x => x.Id == homeTeamId || x.Id == awayTeamId)
            .ToListAsync(cancellationToken); // one call to the database

        var homeTeam = teams.FirstOrDefault(x => x.Id == homeTeamId) ?? throw new NotFoundException(nameof(Team), homeTeamId);
        var awayTeam = teams.FirstOrDefault(x => x.Id == awayTeamId) ?? throw new NotFoundException(nameof(Team), awayTeamId);
        
        return (homeTeam, awayTeam);
    }
}