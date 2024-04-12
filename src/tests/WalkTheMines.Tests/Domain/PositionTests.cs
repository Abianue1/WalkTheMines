using NSubstitute.Core;
using WalkTheMines.Domain;

namespace WalkTheMines.Tests.Domain;

public class PositionTests
{
    [Theory]
    [InlineData(9, 2, 8, "x")]
    [InlineData(2, 6, 5, "y")]
    public void Constructor_IfPositionIsOutSideOfBoardSize_ShouldThrowArgumentOutOfRangeException(int x, int y, int boardSize, string nameOfOutParameterOutOfRange)
    {
        // Act
        Action act = () => new Position(x, y, boardSize);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(nameOfOutParameterOutOfRange, act);
    }

    [Fact]
    public void Constructor_IfPositionIsInsideOfBoardSize_ShouldSetXAndYCorrectly()
    {
        // Arrange
        int x = 3;
        int y = 4;
        int boardSize = 8;

        // Act
        Position position = new Position(x, y, boardSize);

        // Assert
        Assert.Equal(x, position.X);
        Assert.Equal(y, position.Y);
    }

    [Theory]
    [InlineData(1, 1, 8, "A1")]
    [InlineData(8, 2, 8, "H2")]
    [InlineData(3, 8, 8, "C8")]
    public void ToString_ShouldConvertToChessAnnotation(int x, int y, int squareBoardSize, string chessAnnotation)
    {
        // Arrange
        Position position = new Position(x, y, squareBoardSize);

        // Act
        string result = position.ToString();

        // Assert
        Assert.Equal(chessAnnotation, result);
    }
}
