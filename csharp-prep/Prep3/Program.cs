using System;
using System.Collections.Generic;

class Program
{
    //private bool boolean;
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        string numStr = Console.ReadLine();
        int num = Convert.ToInt32(numStr);

        Console.Write("What is your Guess? ");
        string guess = Console.ReadLine();
        int guessedNum = Convert.ToInt32(guess);

        while (guessedNum != num)
        {
            if (guessedNum < num)
            {
                Console.WriteLine("Higher");
            }
            else if (guessedNum > num)
            {
                Console.WriteLine("Lower");
            }
            Console.WriteLine("WHat is your guess?");
            guess = Console.ReadLine();
            guessedNum = Convert.ToInt32(guess);
        }

        if (guessedNum == num)
        {
            Console.WriteLine("You got it!");
        }
    }

}