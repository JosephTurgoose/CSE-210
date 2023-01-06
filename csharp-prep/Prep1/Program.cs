using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();
        Console.WriteLine();
        // Convert first character to uppercase
        firstName = (char.ToUpper(firstName[0]) + firstName.Substring(1)).ToString();
        lastName = (char.ToUpper(lastName[0]) + lastName.Substring(1)).ToString();
        // Print name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}