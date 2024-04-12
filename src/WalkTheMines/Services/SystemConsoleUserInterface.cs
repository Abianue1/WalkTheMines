using WalkTheMines.Interfaces;

namespace WalkTheMines.Services;


public class SystemConsoleUserInterface : IUserInterface
{

    public void DisplayMessageToUser(string message, bool appendNewline = true)
    {
        Console.Write(message);
        if (appendNewline)
            Console.Write(Environment.NewLine);
    }

    public string GetInputFromUser()
    {
        return Console.ReadLine() ?? "";
    } 
}
