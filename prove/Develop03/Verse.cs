using System;

public class Verse
{
    private string _text = "";
    private List<Word> _words = new List<Word>();
    private Random rand;
    private List<Word> hiddenWords = new List<Word>();


    public Verse(string text)
    {
        _text = text;
        foreach (string newWord in text.Split())
        {
            Word word = new Word(newWord);
            _words.Add(word);
        }
    }

    public void Display()
    {
        foreach(Word word in _words)
        {
            word.Display();
            Console.Write(" ");
        }
    }




    public bool Hide(int amountOfVerses)
    {
        // Variables
        rand = new Random();
        Word randomWord = _words[rand.Next(_words.Count)];
        int i = 4/amountOfVerses;
        if (i <= 0)
        {
            i = 1;
        }
        // Run
        for (int n = i; n>0; n--)
        {
            if (randomWord.Hide() == true)
            {
                hiddenWords.Add(randomWord);
            }
            else
            {
                ReHide();
            }
        }
        // End
        if (hiddenWords.Count >= _words.Count)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    // Rehide
    public void ReHide()
    {
        rand = new Random();
        Word randomWord = _words[rand.Next(_words.Count)];
        if (hiddenWords.Count >= _words.Count)
        {
            return;
        }
        if (hiddenWords.Contains(randomWord))
        {
            ReHide();
        }
        else
        {
            if (randomWord.Hide() == true)
            {
                hiddenWords.Add(randomWord);
            }
            else
            {
                ReHide();
            }
        }
    }

    public void Clear()
    {
        foreach (Word word in _words)
        {
            word.Hide();
        }
    }

}