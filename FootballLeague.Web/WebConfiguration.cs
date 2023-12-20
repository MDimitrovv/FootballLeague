namespace FootballLeague.Web;

using Application;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static IServiceCollection AddWeb(this IServiceCollection services)
    {
        services
            .AddValidation()
            .AddControllers();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
        => services
            .AddFluentValidation(validation => validation
            .RegisterValidatorsFromAssemblyContaining<Result>());
}