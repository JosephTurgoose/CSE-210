using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string answer = Console.ReadLine();
        float percentage = float.Parse(answer);
        Console.WriteLine();

        string letter = "";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 87)
        {
            letter = "A-";
        }
        else if (percentage >= 83)
        {
            letter = "B+";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 77)
        {
            letter = "B-";
        }
        else if (percentage >= 73)
        {
            letter = "C+";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 67)
        {
            letter = "C-";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else if (percentage < 60)
        {
            letter = "F";
        }
        
        Console.WriteLine($"Your grade is: {letter}");
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("You failed the class.  Keep improving and you'll get it next time!");
        }

    }
}