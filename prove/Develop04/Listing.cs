using System;
using System.Threading;

class Listing : Activity
{
    private List<string> _prompts = new List<string>{"List as many people you love as possible!",
                                                    "List all the productive things you did today!",
                                                    "List all your personal strengths!",
                                                    "List all the times you have felt the Holy Ghost today!"};
    public Listing(string activityName, string description, string endMessage) : base(activityName, description, endMessage)
    {
        
    }
    
    public void Play()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(0, _prompts.Count())];

        this.PlayActivity();

        Console.WriteLine("Please enter a number of seconds you would like to do this activity.");
        float timeSeconds = float.Parse(Console.ReadLine());
        Wait(750);
        Console.WriteLine($"Your prompt is... {prompt}");
        Wait(5500);
        Console.WriteLine("Ready...");
        Wait(1000);
        Console.WriteLine("Go!");
        Wait(250);
        Console.Write("");

        // Start the countdown in a separate thread
        var countdownThread = new Thread(() => {
            for (float i = timeSeconds; i >= 0; i--)
            {
                Thread.Sleep(1000);
            }
        });
        countdownThread.Start();

        // Keep reading user input until the countdown is complete
        while (countdownThread.IsAlive)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
        }

        EndActivity();
    }
}