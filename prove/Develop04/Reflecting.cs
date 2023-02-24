using System;

class Reflecting : Activity
{
    private List<string> _prompts = new List<string>{"Think of a time when you stood up for someone else.",
                                                    "Think of a time when you did something really difficult.",
                                                    "Think of a time when you made someone smile by doing service for them.",
                                                    "Think of a time you felt the Holy Ghost strongly.",
                                                    "Think of a time when you did something inspired / inspiring."
    };

    private List<string> _questions = new List<string>{"Why was this experience meaningful to you?",
                                                "What are some other time you have done this before?",
                                                "How did this situation start?",
                                                "How did you feel when it was complete?",
                                                "What was your favorite part of this experience?",
                                                "What can you learn from this situation?",
                                                "What did you learn about yourself through this experience?",
                                                "What will you do to make sure these good experiences will keep happening?"
    };
    public Reflecting(string activityName, string description, string endMessage) : base(activityName, description, endMessage)
    {
        
    }
    
    public void Play()
    {
        this.PlayActivity();

        Console.WriteLine("Please enter a number of seconds you would like to do this activity.");
        float timeSeconds = float.Parse(Console.ReadLine());
        Wait(750);
        Console.WriteLine("Ready...");
        Wait(850);
        Console.WriteLine("Go!");
        Wait(200);
        Console.Write("");

        // Start the countdown in a separate thread
        var countdownThread = new Thread(() => {
            for (float i = timeSeconds; i >= 0; i--)
            {
                Thread.Sleep(1000);
            }
        });
        countdownThread.Start();

        while (countdownThread.IsAlive)
        {
            Console.WriteLine();
            string prompt = _prompts[GetRandomNumber().Next(0, _prompts.Count())];
            Console.WriteLine(prompt);
            if (!countdownThread.IsAlive)
            {
                break;
            }
            Wait(8000);
            if (!countdownThread.IsAlive)
            {
                break;
            }
            string question = _questions[GetRandomNumber().Next(0, _questions.Count())];
            Console.WriteLine();
            Console.WriteLine(question);
            if (!countdownThread.IsAlive)
            {
                break;
            }
            Wait(8000);
            Console.WriteLine();
            Console.WriteLine("------------");
        }
        
        EndActivity();
    }

    public Random GetRandomNumber()
    {
        Random random = new Random();
        return random;
    }
}