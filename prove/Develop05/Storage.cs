using System;

public class Storage
{
    private List<Goal> _goals = new List<Goal>();
    private List<Goal> _sortedGoals = new List<Goal>();
    private List<String> _dataString = new List<string>();
    private int _score = 0;

    public void Save()
    {
        // Get File Name
        Console.WriteLine("Please enter a name for this file.");
        string fileName = Console.ReadLine();
        // Update File if it already exists
        if (File.Exists(fileName))
        {
            System.IO.File.WriteAllText(fileName, string.Empty);

            List<String> newList = new List<string>();
            foreach (Goal goal in _sortedGoals)
            {
                newList.Add($"{goal.Display()}\n|");
            }
            //
            File.AppendAllLines(fileName, newList);
        }
        else
        {
            // save the entry to a new file with a name of [fileName];
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (Goal goal in _sortedGoals)
                {
                    //
                    outputFile.WriteLine($"{goal.Display()}\n|");
                }
            }
        }
    }

    public void Load()
    {
        // Clear current data
        _goals.Clear();
        _sortedGoals.Clear();
        // Get File Name
        Console.WriteLine("Please enter the name of the file to load.");
        string fileName = Console.ReadLine();
        // If File Exists
        if (File.Exists(fileName))
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            List<string> oldEntries = new List<string>();
            // Store lines into the oldEntries list
            foreach (string line in lines)
            {
                oldEntries.Add(line);
                // At the entry separation point, add entry to _entryList and clear the stored lines.
                if (line == "|")
                {
                    if (oldEntries != null)
                    {
                        // Compile old lines into an entry
                        var compiledEntry = "";
                        foreach (string oldLine in oldEntries)
                        {
                            if (oldLine != "|")
                            {
                                compiledEntry = ($"{compiledEntry}\n{oldLine}");
                            }
                        }
                        // put compiled entry into _entryList
                        _dataString.Add(compiledEntry);
                    }
                }
                oldEntries.Clear();
                // Obtain Variables
                Goal goal;
                string[] splitLine = line.Split();
                if (splitLine[0] != "|")
                {
                    // Type
                    if (splitLine[0] == "Simple:") // Simple
                    {
                        goal = new SimpleGoal("Simple");
                    }
                    else if (splitLine[0] == "Checklist:") // Checklist
                    {
                        goal = new ChecklistGoal("Checklist");
                    }
                    else // Eternal
                    {
                        goal = new EternalGoal("Eternal");
                    }
                    // Name
                    goal.SetGoalName(splitLine[2].ToString());
                    // Score
                    if (goal.GetGoalType() == "Eternal" | goal.GetGoalType() == "Simple")
                    {
                        goal.SetScore(int.Parse(splitLine[5]));
                    }
                    else
                    {
                        goal.SetScore(int.Parse(splitLine[10]));
                    }
                    // Points
                    if (goal.GetGoalType() == "Eternal" | goal.GetGoalType() == "Simple")
                    {
                        goal.SetPoints(int.Parse(splitLine[7]));
                    }
                    else
                    {
                        goal.SetPoints(int.Parse(splitLine[12]));
                    }
                    // Is Checked
                    if (splitLine[1] == "[]")
                    {}
                    else // if "[X]"
                    {
                        goal.BecomeChecked();
                    }
                    // Times Done
                    if (goal.GetGoalType() == "Eternal")
                    {
                        goal.SetTimesDone(int.Parse(splitLine[9]));
                    }
                    else if (goal.GetGoalType() == "Checklist")
                    {
                        goal.SetTimesDone(int.Parse(splitLine[4]));
                    }
                    else
                    {
                        if (goal.AskIfChecked() == true)
                        {
                            goal.SetTimesDone(1);
                        }
                        else
                        {
                            goal.SetTimesDone(0);
                        }
                    }
                    // Times Needed
                    if (goal.GetGoalType() == "Checklist")
                    {
                        goal.SetTimesNeeded(7);
                    }

                    AddToGoals(goal);
                }
            }
        }
        // If fileName input is wrong
        else
        {
            Console.WriteLine("File could not be located. Please try again.");
        }
    }












    public void DisplayGoals()
    {
        int number = 0;

        foreach (Goal goal in _goals)
        {
            if (goal.GetGoalType() == "Eternal")
            {
                number += 1;
                Console.WriteLine($"({number.ToString()}) {goal.Display()}");
            }
        }
        foreach (Goal goal in _goals)
        {
            if (goal.GetGoalType() == "Checklist")
            {
                number += 1;
                Console.WriteLine($"({number.ToString()}) {goal.Display()}");
            }
        }
        foreach (Goal goal in _goals)
        {
            if (goal.GetGoalType() == "Simple")
            {
                number += 1;
                Console.WriteLine($"({number.ToString()}) {goal.Display()}");
            }
        }
    }
    public void AddToGoals(Goal goal)
    {
        _goals.Add(goal);
        _sortedGoals.Add(goal);

        int index = 0;
        foreach (Goal listGoal in _goals)
        {
            if (listGoal.GetGoalType() == "Eternal")
            {
                _sortedGoals.Remove(listGoal);
                _sortedGoals.Insert(index, listGoal);
                index ++;
            }
        }
        foreach (Goal listGoal in _goals)
        {
            if (listGoal.GetGoalType() == "Checklist")
            {
                _sortedGoals.Remove(listGoal);
                _sortedGoals.Insert(index, listGoal);
                index ++;
            }
        }
        foreach (Goal listGoal in _goals)
        {
            if (listGoal.GetGoalType() == "Simple")
            {
                _sortedGoals.Remove(listGoal);
                _sortedGoals.Insert(index, listGoal);
                index ++;
            }
        }
    }
    public Goal GetGoal(int goalIndex)
    {
        return _sortedGoals[goalIndex-1];
    }
    public List<Goal> GetGoalsList()
    {
        return _sortedGoals;
    }
    
    public void UpdateTotalScore(int newScore)
    {
        _score = newScore;
    }
    public int GetTotalScore()
    {
        return _score;
    }
}