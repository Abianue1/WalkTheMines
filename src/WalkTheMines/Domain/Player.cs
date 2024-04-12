
using WalkTheMines.Constants;

namespace WalkTheMines.Domain;

public class Player(int numberOfLives = GameSettings.NumberOfLives, Position? position = null)
{
    public int NumberOfLives { get; private set; } = numberOfLives;
    public Position CurrentPosition { get; set; } = position ?? new Position(1, 1);
    public int NumberOfMoves { get; private set; } = 0;

    public string GetStatusMessage()
    {
        return string.Format(GameMessages.PlayerStatusMessage, CurrentPosition, NumberOfLives, NumberOfMoves);
    }

    public void UpdatePosition(Position newPosition, bool removeAlife)
    {
        CurrentPosition = newPosition;
        NumberOfMoves++;
        if (removeAlife)
            NumberOfLives--;
    }
}
