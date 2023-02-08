using System;

class Program
{
    static void Main(string[] args)
    {
        // Verses
        List<String> verses1 = new List<string>
        {
            "And by the power of the Holy Ghost, ye may know the truth of all things.",
        };

        List<String> verses2 = new List<string>
        {
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.",
        };

        List<String> verses3 = new List<string>
        {
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding.",
            "In all thy ways acknowledge him, and he shall direct thy paths."
        };

        // Scripture References
        string Ref1 = "Moroni 10:5 - ";
        string Ref2 = "John 3:16 - ";
        string Ref3 = "Proverbs 3:5-6 - ";

        // Scriptures
        Scripture scripture1 = new Scripture(verses1, Ref1);
        Scripture scripture2 = new Scripture(verses2, Ref2);
        Scripture scripture3 = new Scripture(verses3, Ref3);

        List<Scripture> scriptures = new List<Scripture>();
        scriptures.Add(scripture1);
        scriptures.Add(scripture2);
        scriptures.Add(scripture3);

        

        // Select a random Scripture to show
        Random rand = new Random();
        Scripture randomScripture = scriptures[rand.Next(scriptures.Count)];

        // Program
        Console.Clear();
        randomScripture.Display();
        bool running = true;
        while (running == true)
        {
            string input = Console.ReadLine();
            if (input == "quit" | input == "Quit" | input == "QUIT")
            {
                break;
            }
            else
            {
                if (randomScripture.Hide() == true)
                {
                    Console.Clear();
                    randomScripture.Display();
                }
                else
                {
                    randomScripture.Hide();
                    randomScripture.Clear();
                    Console.Clear();
                    randomScripture.Display();
                    Console.ReadLine();
                    break;
                }


            }

        }






    }


}