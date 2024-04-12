using NSubstitute;
using WalkTheMines.Constants;
using WalkTheMines.Domain;
using WalkTheMines.Interfaces;

namespace WalkTheMines.Tests;

public class GameTests
{
    private IUserInterface _userInterface;

    public GameTests()
    {
        _userInterface = Substitute.For<IUserInterface>();
    }

    [Fact]
    public void Start_ShouldDisplayWelcomeMessageOnce()
    {
        // Arrange
        var game = new Game(_userInterface, new Player(0));

        // Act
        game.Start();

        // Assert
        _userInterface.Received(1).DisplayMessageToUser(GameMessages.WelcomeMessage);
    }

    [Fact]
    public void Start_IfPlayerHasZeroLives_ShouldDisplayGameOver()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        var game = new Game(userInterface, new Player(0));

        // Act
        game.Start();

        // Assert
        userInterface.Received(1).DisplayMessageToUser(GameMessages.GameOverLoseMessage);
    }
}
