using System;

class Assignment
{
    string _studentName;
    string _topic;

    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    public string GetSummary()
    {
        return ($"{_studentName} - {_topic}");
    }

}