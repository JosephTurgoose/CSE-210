using System;

class Breathing : Activity
{
    public Breathing(string activityName, string description, string endMessage) : base(activityName, description, endMessage)
    {
        
    }

    public void Play()
    {
        this.PlayActivity();

        Console.WriteLine("Please enter a number of seconds you would like to do this activity.");
        float timeSeconds = float.Parse(Console.ReadLine());
        Wait(750);
        Console.WriteLine("Ready...");
        Wait(1000);
        Console.WriteLine("Go!");
        Wait(750);
        Console.Write(" ");

        while (timeSeconds > 0)
        {
            // In ---------------------------------
            Console.Write("\b \b");
            Console.WriteLine("Breathe in...");
            Console.Write("3");          //3
            Wait(1000);
            timeSeconds -= 1;
            if (timeSeconds <= 0)
            {
                break;
            }
            Console.Write("\b \b");
            Console.Write("2");         //2
            Wait(1000);
            timeSeconds -= 1;
            if (timeSeconds <= 0)
            {
                break;
            }
            Console.Write("\b \b");
            Console.Write("1");        //1
            Wait(1000);
            timeSeconds -= 1;
            if (timeSeconds <= 0)
            {
                break;
            }
            // Out --------------------------------
            Console.Write("\b \b");
            Console.WriteLine("Breath out...");
            Console.Write("3");      //3
            Wait(1000);
            timeSeconds -= 1;
            if (timeSeconds <= 0)
            {
                break;
            }
            Console.Write("\b \b");
            Console.Write("2");       //2
            Wait(1000);
            timeSeconds -= 1;
            if (timeSeconds <= 0)
            {
                break;
            }
            Console.Write("\b \b");
            Console.Write("1");         //1
            Wait(1000);
            timeSeconds -= 1;
        }
        Console.WriteLine("\b \b");
        EndActivity();
    }


}