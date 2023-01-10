using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int num = PromptUserNumber();
        float sqNum = SquareNumber(num);
        DisplayResult(userName, sqNum.ToString());
    }



    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("What is your name?");
        string givenName = Console.ReadLine();
        return givenName;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please input a number.");
        string numberString = Console.ReadLine();
        int number = Convert.ToInt32(numberString);
        return number;
    }

    static float SquareNumber(int num)
    {
        int sqNum = num * num;
        return sqNum;
    }

    static void DisplayResult(string userName, string answer)
    {
        Console.WriteLine($"{userName}, the square of your number is {answer}.");
    }
}