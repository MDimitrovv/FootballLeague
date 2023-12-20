namespace FootballLeague.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

internal class FootballLeagueDbContextInitializer : IInitializer
{
    private readonly FootballLeagueDbContext _db;

    public FootballLeagueDbContextInitializer(FootballLeagueDbContext dbContext) => _db = dbContext;

    public void Initialize() => _db.Database.Migrate();
}