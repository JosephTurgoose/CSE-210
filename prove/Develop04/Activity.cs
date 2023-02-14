using System;
public class Activity
{
    private string _activityName;
    private string _description;

    public Activity(string activityName, string description)
    {
        // Console.WriteLine($"Hello, and welcome to the {activityName}!");
        // Console.WriteLine();
        // Console.WriteLine(description);
        _activityName = activityName;
        _description = description;
    }

    public void PlayActivity()
    {
        // Write greetings
        // Write details on the activity
        // Call each activity's Play() method
    }


    public void Wait()
    {
        // Create a spinning cursor
        // ? Count and store the seconds that pass
    }
}
