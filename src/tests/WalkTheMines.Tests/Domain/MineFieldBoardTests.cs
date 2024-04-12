using WalkTheMines.Constants;
using WalkTheMines.Domain;

namespace WalkTheMines.Tests.Domain;

public class MineFieldBoardTests
{
    [Fact]
    public void DisplayEndPositionRange_ShouldReturnCorrectRange()
    {
        // Arrange
        int chessBoardSize = 8;
        MineFieldBoard mineFieldBoard = new MineFieldBoard(chessBoardSize);

        // Act
        string range = mineFieldBoard.DisplayEndPositionRange();

        // Assert
        string expectedRange = "A8 - H8";
        Assert.Equal(expectedRange, range);
    }

    [Theory]
    [InlineData("W", 1, 1, 1, 2, true, "")]
    public void TryMovePlayer_ShouldReturnExpectedResult(string input, int startX, int startY, int expectedX, int expectedY, bool expectedMineHit, string expectedErrorMessage)
    {
        // Arrange
        var mineFieldBoard = new MineFieldBoard();
        var player = new Player(position: new Position(startX, startY));

        // Act
        var result = mineFieldBoard.TryMovePlayer(input, player);

        // Assert
        Assert.Equal(expectedX, player.CurrentPosition.X);
        Assert.Equal(expectedY, player.CurrentPosition.Y);
        Assert.Equal(expectedMineHit, result.moveSuccessful);
        Assert.Equal(expectedErrorMessage, result.errorMessage);
    }

    [Fact]
    public void MovePlayer_WithNullPlayer_ShouldThrowArgumentNullException()
    {
        // Arrange
        MineFieldBoard mineFieldBoard = new MineFieldBoard();
        Player? player = null;

        // Act
        Action act = () => mineFieldBoard.TryMovePlayer("A1", player);

        // Assert
        Assert.Throws<ArgumentNullException>("player", act);
    }

    [Fact]
    public void MovePlayer_WithInValidInput_MoveSuccefullShouldBeNullAndUserPositionShouldUnchanged()
    {
        // Arrange
        MineFieldBoard mineFieldBoard = new MineFieldBoard();
        Player player = new Player(3);
        var userPosition = player.CurrentPosition;
        string userInput = "z";

        // Act
        var result = mineFieldBoard.TryMovePlayer(userInput, player);

        // Assert
        Assert.False(result.moveSuccessful);
        Assert.Equal(string.Format(GameMessages.InvalidMoveInputMessage, userInput.ToUpper()), result.errorMessage);
        Assert.Equal(userPosition, player.CurrentPosition);
    }
}
