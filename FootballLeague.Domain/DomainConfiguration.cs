namespace FootballLeague.Domain;

using Factories;
using Microsoft.Extensions.DependencyInjection;

// register factories automatically with Scrutor
public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IFactory<>)))
                .AsMatchingInterface()
                .WithTransientLifetime());
}