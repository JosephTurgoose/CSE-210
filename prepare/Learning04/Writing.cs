using System;

class Writing : Assignment
{
    string _title;
    public Writing(string name, string topic, string title) : base (name, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return ($"{GetSummary()} - {_title}");
    }
}