namespace FootballLeague.Infrastructure.Persistence.Configurations;

using Domain.Models.Matches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .HasQueryFilter(m => !m.IsDeleted);

        builder
            .Property(m => m.Attendance)
            .HasDefaultValue(0);

        builder
            .Property(m => m.HomeTeamGoals)
            .HasDefaultValue(0);
        
        builder
            .Property(m => m.AwayTeamGoals)
            .HasDefaultValue(0);

        builder
            .HasOne(ht => ht.HomeTeam)
            .WithMany()
            .HasForeignKey(ht => ht.HomeTeamId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(at => at.AwayTeam)
            .WithMany()
            .HasForeignKey(at => at.AwayTeamId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}