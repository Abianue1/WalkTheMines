
namespace WalkTheMines.Interfaces;

public interface IUserInterface
{
    void DisplayMessageToUser(string message, bool appendNewline = true);  
    string GetInputFromUser();
}

