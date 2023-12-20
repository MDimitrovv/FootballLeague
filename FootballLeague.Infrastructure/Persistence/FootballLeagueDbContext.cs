namespace FootballLeague.Infrastructure.Persistence;

using System.Reflection;
using Domain.Models.Matches;
using Domain.Models.Teams;
using Microsoft.EntityFrameworkCore;

internal class FootballLeagueDbContext : DbContext
{
    public FootballLeagueDbContext(DbContextOptions<FootballLeagueDbContext> options)
    :base(options)
    {
    }

    public DbSet<Team> Teams { get; set; } = default!;
    
    public DbSet<Match> Matches { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}