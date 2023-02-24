using System;
public class Activity
{
    private string _activityName;
    private string _description;
    private string _endingMessage;
    private int _performanceCount = 0;

    public Activity(string activityName, string description, string endMessage)
    {
        _activityName = activityName;
        _description = description;
        _endingMessage = endMessage;
    }

    public void PlayActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}!");
        Wait(1500);
        Console.WriteLine(_description);
        Wait(5250);
    }


    public void Wait(int milliseconds)
    {
        Cursor(milliseconds);
    }

    private void Cursor(float milliseconds)
    {
        while (milliseconds > 0)
        {
            Console.Write("|");
            Thread.Sleep(350); // Thread.Sleep takes in a number of milliseconds to wait.
            milliseconds -= 350;
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(350);
            milliseconds -= 350;
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(350);
            milliseconds -= 350;
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(350);
            milliseconds -= 350;
            Console.Write("\b \b");
        }
    }

    public void EndActivity()
    {
        Wait(500);
        Console.WriteLine();
        Console.WriteLine(_endingMessage);
        Wait(5500);
        _performanceCount ++;
    }

    public int PerformanceCount()
    {
        return _performanceCount;
    }
}
