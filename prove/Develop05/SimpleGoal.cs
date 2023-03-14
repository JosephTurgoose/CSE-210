using System;

class SimpleGoal : Goal
{

    public SimpleGoal(string type) : base (type)
    {

    }

    public override void Create()
    {
        SetGoalName();
        SetPoints();
    }
    public override void Update()
    {
        Console.WriteLine("Yes/No: Did you complete this goal? ");
        string answer = Console.ReadLine();
        if (answer == "Yes")
        {
            BecomeChecked();
            Console.WriteLine("Congratulation! You have checked off your goal. Select 'Display Goals' in order to see your progress.");
            IncreaseScore(1);
        }

        // Press any button to continue
        Console.WriteLine("Press any button to continue.");
        Console.ReadLine();
    }
    public override string Display()
    {
        if (AskIfChecked() == false)
        {
            return ($"Simple: [] {GetGoalName()} - Points(earned/value) {this.GetScore().ToString()} / {this.GetPoints()}");
        }
        else
        {
            return ($"Simple: [X] {GetGoalName()} - Points(earned/value) {this.GetScore().ToString()} / {this.GetPoints()}");
        }
    }
}