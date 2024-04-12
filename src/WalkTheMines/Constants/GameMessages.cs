
namespace WalkTheMines.Constants;

public class GameMessages
{
    public static readonly string WelcomeMessage = "Welcome to Walk the Mines! \n" +
        "You are in a minefield scattered across a " + GameSettings.ChessBoardSize + "x" + GameSettings.ChessBoardSize + " chess Board.\n" +
        "Try to get to the other side without hitting one of them.\n" +
        "When you hit a mine you lose a life. You have " + GameSettings.NumberOfLives + " lives. \n" +
        "Final score is the number of moves taken in order to reach the other side of the board.\n" +
        "May your way be Mine-free!!!";

    public const string GameOverWinMessage = "Congratulations! You've reached {0} intact with {1} moves. Well done!";

    public const string MoveOptionMessage = "Input move direction (up (W), down(S), left(A), right(D)) and press Enter";

    public const string GameOverLoseMessage = "Game Over! You have lost all your lives.";

    public const string PlayerStatusMessage = "Position:{0}. You have {1} lives left. No of moves:{2}";

    public const string InvalidMoveInputMessage = "Invalid move: {0}. Please try again.";

    public const string MovementNotPossibleErrorMessage = "Blocked!!! Cannot move in that direction: {0}.";

    public const string MineHitMessage = "Boom! You hit a mine. You lose a life.";
}
