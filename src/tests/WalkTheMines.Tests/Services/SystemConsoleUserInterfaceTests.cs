using WalkTheMines.Services;

namespace WalkTheMines.Tests.Services;

public class SystemConsoleUserInterfaceTests : IDisposable
{
    private StringWriter _mockTestWriter;
    private StringReader _mockTestReader;

    public void Dispose()
    {
        Console.SetOut(Console.Out);
        _mockTestWriter?.Dispose();
        _mockTestReader?.Dispose();
    }

    [Fact]
    public void DisplayMessageToUser_WithAppendNewLineTrue_ShouldWriteCorrectMessageToConsole()
    {
        // Arrange
        _mockTestWriter = new StringWriter();
        Console.SetOut(_mockTestWriter);
        var userInterface = new SystemConsoleUserInterface();
        var message = "Let's begin";

        // Act
        userInterface.DisplayMessageToUser(message, true);

        // Assert
        Assert.Equal($"{message}" + Environment.NewLine, _mockTestWriter.ToString());
    }

    [Fact]
    public void DisplayMessageToUser_WithAppendNewLineFalse_ShouldWriteCorrectMessageToConsole()
    {
        // Arrange
        _mockTestWriter = new StringWriter();
        Console.SetOut(_mockTestWriter);
        var userInterface = new SystemConsoleUserInterface();
        var message = "Let's begin";

        // Act
        userInterface.DisplayMessageToUser(message, false);

        // Assert
        Assert.Equal(message, _mockTestWriter.ToString());
    }

    [Fact]
    public void GetInputFromUser_ShouldReturnCorrectInputFromConsole()
    {
        // Arrange
        _mockTestReader = new StringReader("test");
        Console.SetIn(_mockTestReader);
        var userInterface = new SystemConsoleUserInterface();

        // Act
        var input = userInterface.GetInputFromUser();

        // Assert
        Assert.Equal("test", input);
    }
}
