namespace FootballLeague.Infrastructure.Persistence.Configurations;

using Domain.Models.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder
            .HasKey(t => t.Id);

        builder
            .HasQueryFilter(t => !t.IsDeleted);
        
        builder
            .Property(t => t.Name)
            .IsRequired();

        builder
            .OwnsOne(t => t.Stadium, stadium =>
            {
                stadium.WithOwner();

                stadium.Property(st => st.Name);
                stadium.Property(st => st.Capacity);
            });
        
        builder
            .OwnsOne(t => t.Statistics, statistics =>
            {
                statistics.WithOwner();

                statistics.Property(st => st.Points);
                statistics.Property(st => st.MatchesPlayed);
                statistics.Property(st => st.Wins);
                statistics.Property(st => st.Draws);
                statistics.Property(st => st.Losses);
                statistics.Property(st => st.GoalsFor);
                statistics.Property(st => st.GoalsAgainst);
            });
    }
}