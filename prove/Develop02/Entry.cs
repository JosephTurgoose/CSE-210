using System;


public class Entry
{
    private string prompt;    
    public string _entry = "";

    private List<string> prompts = new List<string>();

    public void WriteEntry()
    {
        // Prompt, response, date - compile
        Prompt();
        string response = Console.ReadLine();
        string now = DateTime.Now.ToString();
        _entry = ($"{now}\n{prompt}\n{response}");
        // save the entry to the end of the entries list;
        //_entries.Add(_entry);
    }

        private void Prompt()
    {
        prompts.Add("What was something exciting that happened today?");
        prompts.Add("Who is an interesting person you spoke to today?");
        prompts.Add("What was stressful about today?");
        prompts.Add("What is the best food you had today?");
        prompts.Add("What is a cool place you visited today?");

        var random = new Random();
        var rand = random.Next(prompts.Count());
        prompt = prompts[rand];
        Console.WriteLine(prompt);
    }
}