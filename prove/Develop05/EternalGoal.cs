using System;

class EternalGoal : Goal
{
    public EternalGoal(string type) : base (type)
    {

    }


    public override void Create()
    {
        SetGoalName();
        SetPoints();
    }
    public override void Update()
    {
        Console.WriteLine("How many times have you completed this goal? ");
        int answer = int.Parse(Console.ReadLine());
        IncreaseTimesDone(answer);
        IncreaseScore(answer);
        Console.WriteLine("Select 'Display Goals' in order to see your progress.");

        // Press any button to continue
        Console.WriteLine("Press any button to continue.");
        Console.ReadLine();
    }
    public override string Display()
    {
        return ($"Eternal: [] {GetGoalName()} - Points(earned/value) {this.GetScore().ToString()} / {this.GetPoints()} - {GetTimesDone().ToString()} times done");
    }
}