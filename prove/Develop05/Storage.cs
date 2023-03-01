using System;

class Storage
{
    private List<Goal> goals = new List<Goal>();
    private int _score = 0;

    public void AddToScore(int amount)
    {
        _score += amount;
    }

    public string DisplayScore()
    {
        return ($"Your current score is: {_score.ToString()}");
    }

}