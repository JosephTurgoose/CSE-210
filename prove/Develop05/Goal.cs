using System;

public abstract class Goal
{
    private bool _isChecked = false;
    private string _goalName = "";
    private string _goalType = "";
    private int _points;
    private int _pointsScored;
    private int _timesDone, _timesNeeded;

    public Goal(string type)
    {
        _goalType = type;
        //Create();
    }

    public abstract void Create();
    public abstract void Update();
    public abstract string Display();

    public void SetGoalName()
    {
        Console.WriteLine("Please enter a title/description for your goal. ");
        _goalName = Console.ReadLine();
        // Change Spaces to Underscores for Saving purposes
        _goalName = _goalName.Replace(' ', '_');

    }
    public void SetGoalName(string name)
    {
        _goalName = name;
    }
    public string GetGoalName()
    {
        return _goalName;
    }


    public string GetGoalType()
    {
        return _goalType;
    }

    public void SetPoints()
    {
        Console.WriteLine("How many points should this goal be worth?");
        _points = int.Parse(Console.ReadLine());
    }
    public void SetPoints(int number)
    {
        _points = number;
    }
    public int GetPoints()
    {
        return _points;
    }
    public void IncreaseScore(int times)
    {
        _pointsScored += _points * times;
    }
    public void SetScore(int value)
    {
        _pointsScored = value;
    }
    public int GetScore()
    {
        return _pointsScored;
    }

    
    public void BecomeChecked()
    {
        _isChecked = true;
    }
    public bool AskIfChecked()
    {
        return _isChecked;
    }

    public void SetTimesNeeded()
    {
        Console.WriteLine("How many times do you need to complete this activity in order to finish the goal?");
        _timesNeeded = int.Parse(Console.ReadLine());
    }
    public void SetTimesNeeded(int number)
    {
        _timesNeeded = number;
    }

    public void IncreaseTimesDone(int number)
    {
        _timesDone += number;
    }
    public void SetTimesDone(int number)
    {
        _timesDone = number;
    }
    public int GetTimesDone()
    {
        return _timesDone;
    }
    public int GetTimesNeeded()
    {
        return _timesNeeded;
    }
}