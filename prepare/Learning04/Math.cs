using System;

class Math : Assignment
{
    string _problems;
    string _textbookSection;
    public Math(string name, string topic, string problems, string textbookSection) : base (name, topic)
    {
        _problems = problems;
        _textbookSection = textbookSection;
    }

    public string GetHomeworkList()
    {
        return ($"{GetSummary()} - {_textbookSection} - {_problems}");
    }
    
}