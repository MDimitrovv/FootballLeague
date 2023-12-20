namespace FootballLeague.Domain.Models.Matches;

using FluentAssertions;
using Xunit;
using static MatchFakes;
using static Teams.TeamFakes;


public class MatchSpecs
{
    private const int WinPoints = 3;
    private const int DrawPoints = 1;
    
    [Fact]
    public void Draw_Match_Should_Add_One_Point_And_One_Draw_To_Each_Team_Statistics()
    {
        // Arrange
        const int homeTeamGoals = 1;
        const int awayTeamGoals = 1;
        
        var homeTeam = GenerateFakeTeam();
        var awayTeam = GenerateFakeAwayTeam();
        
        // Act
        var match = new Match(homeTeam, homeTeamGoals, awayTeam, awayTeamGoals, 55000);
        homeTeam.Statistics.UpdateStatistics(homeTeamGoals, awayTeamGoals);
        awayTeam.Statistics.UpdateStatistics(awayTeamGoals, homeTeamGoals);
        
        // Assert
        
        // Home team
        
        match.HomeTeam.Statistics.Wins.Should().Be(0);
        match.HomeTeam.Statistics.Draws.Should().Be(1);
        match.HomeTeam.Statistics.Losses.Should().Be(0);
        match.HomeTeam.Statistics.GoalsFor.Should().Be(homeTeamGoals);
        match.HomeTeam.Statistics.GoalsAgainst.Should().Be(awayTeamGoals);
        match.HomeTeam.Statistics.Points.Should().Be(DrawPoints);
        
        // Away Team
        
        match.AwayTeam.Statistics.Wins.Should().Be(0);
        match.AwayTeam.Statistics.Draws.Should().Be(1);
        match.AwayTeam.Statistics.Losses.Should().Be(0);
        match.AwayTeam.Statistics.GoalsFor.Should().Be(awayTeamGoals);
        match.AwayTeam.Statistics.GoalsAgainst.Should().Be(homeTeamGoals);
        match.AwayTeam.Statistics.Points.Should().Be(DrawPoints);
    }
    
    [Fact]
    public void Winner_Team_Should_Take_Three_Points_And_A_Win_Loser_Zero_Points_And_A_Loss()
    {
        // Arrange
        const int homeTeamGoals = 2;
        const int awayTeamGoals = 1;

        var homeTeam = GenerateFakeTeam();
        var awayTeam = GenerateFakeAwayTeam();
        
        // Act
        var match = new Match(homeTeam, homeTeamGoals, awayTeam, awayTeamGoals, 55000);
        homeTeam.Statistics.UpdateStatistics(homeTeamGoals, awayTeamGoals);
        awayTeam.Statistics.UpdateStatistics(awayTeamGoals, homeTeamGoals);

        // Assert
        
        // Home team
        
        match.HomeTeam.Statistics.Wins.Should().Be(1);
        match.HomeTeam.Statistics.Draws.Should().Be(0);
        match.HomeTeam.Statistics.Losses.Should().Be(0);
        match.HomeTeam.Statistics.GoalsFor.Should().Be(homeTeamGoals);
        match.HomeTeam.Statistics.GoalsAgainst.Should().Be(awayTeamGoals);
        match.HomeTeam.Statistics.Points.Should().Be(WinPoints);
        
        // Away Team
        
        match.AwayTeam.Statistics.Wins.Should().Be(0);
        match.AwayTeam.Statistics.Draws.Should().Be(0);
        match.AwayTeam.Statistics.Losses.Should().Be(1);
        match.AwayTeam.Statistics.GoalsFor.Should().Be(awayTeamGoals);
        match.AwayTeam.Statistics.GoalsAgainst.Should().Be(homeTeamGoals);
        match.AwayTeam.Statistics.Points.Should().Be(0);
    }
    
    [Fact]
    public void Should_Set_Match_To_Deleted()
    {
        // Arrange
        var match = GenerateFakeMatch();
        
        // Act
        match.DeleteMatch();

        // Assert
        match.IsDeleted.Should().Be(true);
    }
}