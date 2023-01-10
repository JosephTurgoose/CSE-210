using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> ints = new List<int>();

        Console.Write("Enter an integer to add to the list. (0 to stop) ");
        string input = Console.ReadLine();
        int integer = Convert.ToInt32(input);

        while (integer != 0)
        {
            ints.Add(integer);

            Console.Write("Enter an integer to add to the list. (0 to stop) ");
            input = Console.ReadLine();
            integer = Convert.ToInt32(input);
        }

        // Find the sum
        int sum = 0;
        foreach (int number in ints)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is {sum}.");

        // Find the average
        float average = 0;
        int amount = 0;
        foreach (int number in ints)
        {
            amount += 1;
        }
        average = (float)sum/(float)amount;
        Console.WriteLine($"The average is {average}.");

        // Find the highest number in the list
        int highest = 0;
        foreach (int number in ints)
        {
            if (number > highest)
            {
                highest = number;
            }
        }
        Console.WriteLine($"The highest number in the list is {highest}.");

    }
}