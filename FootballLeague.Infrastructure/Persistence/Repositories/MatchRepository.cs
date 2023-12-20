namespace FootballLeague.Infrastructure.Persistence.Repositories;

using Application.CQRS.Matches;
using Application.CQRS.Matches.Queries.Common;
using Application.Exceptions;
using AutoMapper;
using Domain.Models.Matches;
using Microsoft.EntityFrameworkCore;

internal class MatchRepository : DataRepository<Match>, IMatchRepository
{
    private readonly IMapper _mapper;

    public MatchRepository(FootballLeagueDbContext db, IMapper mapper)
        : base(db)
        => _mapper = mapper;

    public async Task<Match> FindById(int id, CancellationToken cancellationToken)
        => await All()
               .FirstOrDefaultAsync(m => m.Id == id, cancellationToken) 
           ?? throw new NotFoundException(nameof(Match), id);

    public async Task<MatchDto> SingleMatchDetails(int id, CancellationToken cancellationToken)
        => await _mapper
               .ProjectTo<MatchDto>(All().Where(m => m.Id == id))
               .FirstOrDefaultAsync(cancellationToken) 
           ?? throw new NotFoundException(nameof(Match), id);

    public async Task<IEnumerable<MatchDto>> AllMatches(CancellationToken cancellationToken)
        => await _mapper
            .ProjectTo<MatchDto>(All().OrderByDescending(m => m.Id))
            .ToListAsync(cancellationToken);
}