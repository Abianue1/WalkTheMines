using WalkTheMines.Constants;
using WalkTheMines.Domain;

namespace WalkTheMines.Tests.Domain;

public class PlayerTests
{
    [Fact]
    public void Constructor_ShouldSetNumberOfLivesCorrectly()
    {
        // Arrange
        int numberOfLives = 3;

        // Act
        Player player = new Player(numberOfLives);

        // Assert
        Assert.Equal(numberOfLives, player.NumberOfLives);
    }

    [Fact]
    public void Constructor_ShouldSetCurrentPositionCorrectly()
    {
        // Arrange
        int numberOfLives = 3;

        // Act
        Player player = new Player(numberOfLives);

        // Assert
        Assert.Equal(new(1, 1), player.CurrentPosition);
    }

    [Fact]
    public void Constructor_ShouldSetNumberOfMovesCorrectly()
    {
        // Arrange
        int numberOfLives = 3;

        // Act
        Player player = new Player(numberOfLives);

        // Assert
        Assert.Equal(0, player.NumberOfMoves);
    }

    [Fact]
    public void GetStatusMessage_ShouldReturnCorrectMessage()
    {
        // Arrange
        int numberOfLives = 3;
        Player player = new Player(numberOfLives);

        // Act
        string result = player.GetStatusMessage();

        // Assert
        Assert.Equal(string.Format(GameMessages.PlayerStatusMessage, "A1", numberOfLives, 0), result);
    }

    [Fact]
    public void UpdatePosition_ShouldUpdatePositionCorrectly()
    {
        // Arrange
        int numberOfLives = 3;
        Player player = new Player(numberOfLives);
        Position newPosition = new Position(2, 2);
        bool removeAlife = false;

        // Act
        player.UpdatePosition(newPosition, removeAlife);

        // Assert
        Assert.Equal(newPosition, player.CurrentPosition);
    }

    [Fact]
    public void UpdatePosition_ShouldIncrementNumberOfMoves()
    {
        // Arrange
        int numberOfLives = 3;
        Player player = new Player(numberOfLives);
        Position newPosition = new Position(2, 2);
        bool removeAlife = false;

        // Act
        player.UpdatePosition(newPosition, removeAlife);

        // Assert
        Assert.Equal(1, player.NumberOfMoves);
    }

    [Fact] 
    public void UpdatePosition_WithRemoveAlifeTrue_ShouldDecrementNumberOfLives()
    {
        // Arrange
        int numberOfLives = 3;
        Player player = new Player(numberOfLives);
        Position newPosition = new Position(2, 2);
        bool removeAlife = true;

        // Act
        player.UpdatePosition(newPosition, removeAlife);

        // Assert
        Assert.Equal(numberOfLives - 1, player.NumberOfLives);
    }
}
