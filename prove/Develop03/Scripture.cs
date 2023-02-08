using System;

public class Scripture
{
    private List<Verse> _verses = new List<Verse>();
    private string _reference = "";

    public Scripture(List<string> verses, string reference)
    {
        foreach (string newVerse in verses)
        {
            Verse verse = new Verse(newVerse);
            _verses.Add(verse);
        }

        _reference = reference;
    }


    public void Display()
    {
        Console.Write(_reference);
        foreach (Verse v in _verses)
        {
            v.Display();
            if (_verses.Count > 1)
            {
                Console.Write("|| ");
            }
        }
    }

    public bool Hide()
    {
        bool isTrue = true;
        int amountOfVerses = 0;
        // To hide stuff
        if (isTrue == true)
        {
            foreach (Verse verse in _verses)
            {
                amountOfVerses++;
            }
            foreach (Verse verse in _verses)
            {
                if(verse.Hide(amountOfVerses)==true)
                {
                    isTrue = false;
                }
            }
        }

        // To stop the program
        if (isTrue == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Clear()
    {
        foreach (Verse verse in _verses)
        {
            verse.Clear();
        }
    }

}