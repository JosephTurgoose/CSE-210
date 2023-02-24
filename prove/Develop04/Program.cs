using System;

class Program
{
    static void Main(string[] args)
    {
        // Assign each activity its variables
        Breathing breathing = new Breathing("breathing activity",
            "This activity helps to calm our minds and bodies by breathing in slowly, and breathing out slowly. You will see a prompting for when you should breathe in and out. Remember to remain relaxed throughout this activity.",
            "The breathing activity is now over. We hope that exercise was able to clear your mind and help to refresh you :)");
        Listing listing = new Listing("listing activity",
            "For this activity you will be given a random prompt for things to list off.  When prompted to go, start typing and don't stop until the timer runs out!",
            "The listing activity is now over. We hope this activity was helpful in bringing you peace and joy today :)");
        Reflecting reflecting = new Reflecting("reflecting activity",
            "For this activity you don't have to type anything other than the timer.  Your job is to read the prompts and questions shown and reflect on them for the duration of the time.",
            "The reflecting activity is now over. We hope this activity helped to strengthen your view of yourself and helps you to keep a grateful attitude :)");

        string input = "1";
        while (input == "1" | input == "2" | input == "3")
        {
            Console.Clear();

            Console.WriteLine($"You have done the breathing activity {breathing.PerformanceCount()} times this session.");
            Console.WriteLine($"You have done the listing activity {listing.PerformanceCount()} times this session.");
            Console.WriteLine($"You have done the reflecting activity {reflecting.PerformanceCount()} times this session.");
            Console.WriteLine();

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Breathing");
            Console.WriteLine("2: Listing");
            Console.WriteLine("3: Reflecting");
            Console.WriteLine("4: Quit");

            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    breathing.Play();
                    break;
                case "2":
                    listing.Play();
                    break;
                case "3":
                    reflecting.Play();
                    break;
                default:
                    break;
            }
        }
    }

}