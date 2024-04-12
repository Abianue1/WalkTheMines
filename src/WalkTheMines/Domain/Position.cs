

using WalkTheMines.Constants;

namespace WalkTheMines.Domain;

public record Position
{
    private readonly int _boardSize;

    public Position(int x, int y, int boardSize = GameSettings.ChessBoardSize)
    {
        if (x < 0 || x > boardSize)
            throw new ArgumentOutOfRangeException(nameof(x));

        if (y < 0 || y > boardSize)
            throw new ArgumentOutOfRangeException(nameof(y));

        X = x;
        Y = y;
        _boardSize = boardSize;
    }

    public int X { get; }
    public int Y { get; }

    public override string ToString()
    {
        var chessAnnotation = (char)('A' + X - 1);
        return $"{chessAnnotation.ToString()}{Y}";
    }

    public bool IsValid()
    {
        if (X < 1 || X > _boardSize || Y < 1 || Y > _boardSize)
            return false;

        return true;
    }
}
