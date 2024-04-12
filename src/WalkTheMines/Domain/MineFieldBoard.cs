using WalkTheMines.Constants;
using WalkTheMines.Interfaces;

namespace WalkTheMines.Domain;

public class MineFieldBoard
{
    private readonly int _chessBoardSize;
    private readonly int _noOfMinesPerRow; 
    private List<Position> _minePositions;
    public MineFieldBoard(int chessBoardSize = GameSettings.ChessBoardSize,
                        int noOfMinesPerRow = GameSettings.MinesPerRow)
    {
        _chessBoardSize = chessBoardSize;
        _noOfMinesPerRow = noOfMinesPerRow;       
        _minePositions = new List<Position>();
        InitialiseMines();

    }

    public string DisplayEndPositionRange()
    {
        return new Position(1, _chessBoardSize).ToString() +
            " - " + new Position(_chessBoardSize, _chessBoardSize).ToString();
    }

    public (bool moveSuccessful, string errorMessage) TryMovePlayer(string input, Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));

        input = input.ToUpper();

        if (!IsValidInput(input))
            return (false, string.Format(GameMessages.InvalidMoveInputMessage, input));

        var newPosition = CalculateNewPosition(player.CurrentPosition, input);

        if (!newPosition.IsValid())
            return (false, string.Format(GameMessages.MovementNotPossibleErrorMessage, newPosition.ToString()));

        var isMineHit = DoesNewPositionContainMine(newPosition);

        player.UpdatePosition(newPosition, isMineHit);

        if (isMineHit)
            return (true, GameMessages.MineHitMessage);

        return (true, string.Empty);
    }

    public bool IsPlayerAtEnd(Player player)
    {
        return player.CurrentPosition.Y == _chessBoardSize;
    }

    private bool DoesNewPositionContainMine(Position newPosition)
    {
        return _minePositions.Any(minePosition => minePosition.Equals(newPosition));
    }
    private void InitialiseMines()
    {
        Random random = new Random();

        for (int row = 1; row <= _chessBoardSize; row++)
        {
            HashSet<int> minedColumns = new HashSet<int>();

            for (int mineCount = 1; mineCount <= _noOfMinesPerRow;)
            {
                int column;

                if (row > 1)
                {
                    column = random.Next(1, _chessBoardSize + 1);
                }
                else
                {
                    column = random.Next(2, _chessBoardSize + 1);
                }

                if (minedColumns.Any() && minedColumns.Contains(column))
                {
                    continue;
                }
                else
                {
                    minedColumns.Add(column);
                    _minePositions.Add(new Position(column, row));
                    mineCount++;
                }
            }

        }
    }

    private bool IsValidInput(string input)
    {
        return !string.IsNullOrWhiteSpace(input) && IsInputTextTheAllowedValue(input);
    }

    private bool IsInputTextTheAllowedValue(string input)
    {
        return input == "W" || input == "S" || input == "A" || input == "D";
    }

    private Position CalculateNewPosition(Position currentPosition, string input)
    {
        return input switch
        {
            "W" => new Position(currentPosition.X, currentPosition.Y + 1),
            "S" => new Position(currentPosition.X, currentPosition.Y - 1),
            "A" => new Position(currentPosition.X - 1, currentPosition.Y),
            "D" => new Position(currentPosition.X + 1, currentPosition.Y),
            _ => throw new ArgumentOutOfRangeException(nameof(input))
        };
    }

}
