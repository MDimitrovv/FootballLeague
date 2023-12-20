namespace FootballLeague.Domain.Models.Teams;

using FluentAssertions;
using Xunit;
using static TeamFakes;

public class TeamSpecs
{
    [Fact]
    public void Should_Update_Team_Name()
    {
        // Arrange
        var team = GenerateFakeTeam();
        
        // Act
        team.UpdateName("Liverpool");

        // Assert
        team.Name.Should().Be("Liverpool");
    }
    
    [Fact]
    public void Should_Update_Team_Stadium()
    {
        // Arrange
        var team = GenerateFakeTeam();
        
        // Act
        team.UpdateStadium("Old Trafford", 75000);

        // Assert
        team.Stadium.Name.Should().Be("Old Trafford");
        team.Stadium.Capacity.Should().Be(75000);
    }
    
    [Fact]
    public void Should_Set_Team_To_Deleted()
    {
        // Arrange
        var team = GenerateFakeTeam();
        
        // Act
        team.DeleteTeam();

        // Assert
        team.IsDeleted.Should().Be(true);
    }
}