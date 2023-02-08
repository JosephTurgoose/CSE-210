using System;

public class Word
{
    private string _text = "";
    private bool _hidden = false;
    
    public Word(string text)
    {
        _text = text;
    }

    public void Display()
    {
        Console.Write(_text);
    }

    public bool Hide()
    {
        if (_hidden == false)
        {
            string newText = "";
            foreach (char c in _text)
            {
                newText += "_";
            }
            _text = newText;
            _hidden = true;
            return true;
        }
        else
        {
            return false;
        }
    }



}