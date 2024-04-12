using WalkTheMines.Constants;
using WalkTheMines.Domain;
using WalkTheMines.Interfaces;

namespace WalkTheMines;

public class Game(IUserInterface userInterface, Player newPlayer)
{
    private readonly IUserInterface _userInterface = userInterface;
    private readonly Player _player = newPlayer;
    private readonly MineFieldBoard _mineFieldBoard = new MineFieldBoard();

    public void Start()
    {
        _userInterface.DisplayMessageToUser(GameMessages.WelcomeMessage);

        while (CanContinue())
        {
            _userInterface.DisplayMessageToUser(_player.GetStatusMessage());

            _userInterface.DisplayMessageToUser($"Ending row range: {_mineFieldBoard.DisplayEndPositionRange()}");

            _userInterface.DisplayMessageToUser(GameMessages.MoveOptionMessage, false);

            _userInterface.DisplayMessageToUser(Environment.NewLine);

            var input = _userInterface.GetInputFromUser();

            var moveResult = _mineFieldBoard.TryMovePlayer(input, _player);

            if (!moveResult.moveSuccessful || !string.IsNullOrEmpty(moveResult.errorMessage))
                _userInterface.DisplayMessageToUser(moveResult.errorMessage);
        }
    }

    private bool CanContinue()
    {
        var canContinue = true;
        if (_player.NumberOfLives == 0)
        {
            canContinue = false;
            _userInterface.DisplayMessageToUser(GameMessages.GameOverLoseMessage);
        }
        else if (_mineFieldBoard.IsPlayerAtEnd(_player))
        {
            canContinue = false;
            _userInterface.DisplayMessageToUser(string.Format(GameMessages.GameOverWinMessage, _player.CurrentPosition, _player.NumberOfMoves));
        }
        return canContinue;
    }
}

