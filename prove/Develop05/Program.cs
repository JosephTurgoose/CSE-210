using System;

class Program
{
    static void Main(string[] args)
    {
        Storage storage = new Storage();

        string input = "";
        Console.Clear();


        while (input != "6")
        {
            // Menu
            Console.WriteLine(@"
1.) Create Goal
2.) Update Goal
3.) Display Goals
4.) Save File
5.) Load File
6.) Quit
            ");
            input = Console.ReadLine();
            // Options
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(@"
What type of goal would you like to make?
1.) Eternal
2.) Checklist
3.) Simple
                    ");
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1"://
                            EternalGoal eternalGoal = new EternalGoal("Eternal");
                            eternalGoal.Create();

                            storage.AddToGoals(eternalGoal);
                            Console.Clear();
                            break;
                        case "2"://
                            ChecklistGoal checklistGoal = new ChecklistGoal("Checklist");
                            checklistGoal.Create();

                            storage.AddToGoals(checklistGoal);
                            Console.Clear();
                            break;
                        case "3"://
                            SimpleGoal simpleGoal = new SimpleGoal("Simple");
                            simpleGoal.Create();

                            storage.AddToGoals(simpleGoal);
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Which goal would you like to update (type the goal number)?");
                    int goalIndex = int.Parse(Console.ReadLine());
                    Goal goalToUpdate = storage.GetGoal(goalIndex);
                    Console.Clear();
                    Console.WriteLine(goalToUpdate.Display());
                    Console.WriteLine("Is this the goal you want to update? (1 = yes, 2 = no)");
                    string response = Console.ReadLine();
                    if (response == "1" | response == "yes")
                    {
                        goalToUpdate.Update();
                    }

                    int goalCount = 0;
                    int completedCount = 0;
                    foreach (Goal goal in storage.GetGoalsList())
                    {
                        goalCount ++;
                        if (goal.AskIfChecked() == true & goal.GetGoalType() != "Eternal")
                        {
                            completedCount ++;
                        }
                        else if (goal.GetGoalType() == "Eternal" & goal.GetTimesDone() >= goal.GetTimesNeeded())
                        {
                            completedCount ++;
                        }
                    }
                    if (completedCount == goalCount)
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("Congratulations!!! You've completed all of your goals!");
                    }
                    break;
                case "3":
                    Console.Clear();
                    int number = 0;
                    foreach (Goal goal in storage.GetGoalsList())
                    {
                        number += goal.GetScore();
                    }
                    storage.UpdateTotalScore(number);
                    Console.WriteLine($"You have {storage.GetTotalScore().ToString()} points");
                    storage.DisplayGoals();
                    break;
                case "4":
                    storage.Save();
                    break;
                case "5":
                    storage.Load();
                    break;
            }
        }
    }
}