using System;
using System.IO;

class DataManager
{
    public List<string> _newStuff = new List<string>();
    public List<string> _entryList = new List<string>();
    //public string _entryDate;


    public void SaveEntryToFile()  // Done
    {
        Console.WriteLine("Please enter a name for this file.");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            File.AppendAllLines(fileName, _newStuff);
        }
        else
        {
            // save the entry to a new file with a name of [fileName];
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (string entry in _entryList)
                {
                    outputFile.WriteLine($"{entry}");
                    outputFile.WriteLine("");
                }
            }
        }

    }



    public void LoadEntryFromFile()
    {
        // Clear current entry list
        _entryList.Clear();

        // Get File Name
        Console.WriteLine("Please enter the name of the file to load.");
        string fileName = Console.ReadLine();
        // If File Exists
        if (File.Exists(fileName))
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            List<string> oldEntries = new List<string>();
            // Store lines into the oldEntries list
            foreach (string line in lines)
            {
                oldEntries.Add(line);
                // At the entry separation point, add entry to _entryList and clear the stored lines.
                if (line == "|")
                {
                    if (oldEntries != null)
                    {
                        // Compile old lines into an entry
                        var compiledEntry = "";
                        foreach (string oldLine in oldEntries)
                        {
                            if (oldLine != "|")
                            {
                                compiledEntry = ($"{compiledEntry}\n{oldLine}");
                            }
                        }
                        // put compiled entry into _entryList
                        _entryList.Add(compiledEntry);
                    }
                    oldEntries.Clear();
                }
            }
        }
        // If fileName input is wrong
        else
        {
            Console.WriteLine("File could not be located.  Please try again.");
        }

    }



    public void DisplayJournal()
    {
        // display each file from the entryList list.  Display the filename with each one.
        foreach (string entry in _entryList)
        {
            //Console.WriteLine(_entryDate);
            Console.WriteLine(entry);
            Console.WriteLine("");
        }
    }

}