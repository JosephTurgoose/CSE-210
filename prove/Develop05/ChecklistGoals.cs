using System;

class ChecklistGoal : Goal
{
    private int _timesNeeded;
    public ChecklistGoal(string type) : base (type)
    {

    }

    public override void Create()
    {
        SetGoalName();
        SetPoints();
        
        Console.WriteLine("How many times do you need to complete this activity in order to finish the goal?");
        _timesNeeded = int.Parse(Console.ReadLine());
    }
    public override void Update()
    {
        Console.WriteLine("How many times have you completed this goal? ");
        int answer = int.Parse(Console.ReadLine());
        IncreaseTimesDone(answer);
        IncreaseScore(answer);
        if (GetTimesDone() >= _timesNeeded)
        {
            BecomeChecked();
            Console.WriteLine("Congratulation! You have checked off your goal. Select 'Display Goals' in order to see your progress.");
        }

        // Press any button to continue
        Console.WriteLine("Press any button to continue.");
        Console.ReadLine();
    }
    public override string Display()
    {
        if (AskIfChecked() == false)
        {
            return ($"Checklist: [] {GetGoalName()} - {GetTimesDone().ToString()} / {_timesNeeded.ToString()} - Points(earned/value) {this.GetScore().ToString()} / {this.GetPoints()}");
        }
        else
        {
            return ($"Checklist: [X] {GetGoalName()} - {GetTimesDone().ToString()} / {_timesNeeded.ToString()} - Points(earned/value) {this.GetScore().ToString()} / {this.GetPoints()}");
        }
    }
}