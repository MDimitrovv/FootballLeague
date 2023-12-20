namespace FootballLeague.Infrastructure;

using Application.Contracts;
using Application.CQRS.Matches;
using Application.CQRS.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddDatabase(configuration)
            .AddRepositories()
            .AddTransient<ITeamRepository, TeamRepository>()
            .AddTransient<IMatchRepository, MatchRepository>();

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<FootballLeagueDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(FootballLeagueDbContext).Assembly.FullName)))
            .AddTransient<IInitializer, FootballLeagueDbContextInitializer>();
    
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IRepository<>)))
                .AsMatchingInterface()
                .WithTransientLifetime());
}