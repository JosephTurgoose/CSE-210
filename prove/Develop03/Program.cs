using System;

class Program
{
    static string verse = "hello person";
    static void Main(string[] args)
    {
        foreach (string word in verse.Split())
        {
            Console.WriteLine(word);
        }
    }

    private void WhiteOut()
    {

    }

    private void Quit()
    {

    }

}