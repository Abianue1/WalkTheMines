using WalkTheMines;
using WalkTheMines.Constants;
using WalkTheMines.Domain;
using WalkTheMines.Interfaces;
using WalkTheMines.Services;

IUserInterface consoleUserInterface = new SystemConsoleUserInterface();

var game = new Game(consoleUserInterface, new Player());
game.Start();

