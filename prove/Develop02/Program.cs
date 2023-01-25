using System;

class Program
{
    static void Main(string[] args)
    {
        // Define the Data Manager
        DataManager dataManager = new DataManager();
        // Menu
        Menu menu = new Menu();
        menu.DisplayMenu();
        int input = int.Parse(Console.ReadLine());
        // Actions
        while (input <= 4)
        {
            if (input == 1) // Write New Entry
            {
                // Make an entry
                Entry newEntry = new Entry();
                newEntry.WriteEntry();
                dataManager._entryList.Add($"{newEntry._entry}\n|");
                dataManager._newStuff.Add($"{newEntry._entry}\n|");

                menu.DisplayMenu();
                input = int.Parse(Console.ReadLine());
            }
            else if (input == 2) // Display Journal
            {
                dataManager.DisplayJournal();

                menu.DisplayMenu();
                input = int.Parse(Console.ReadLine());
            }
            else if (input == 3)
            {
                // Save Entry to File
                dataManager.SaveEntryToFile();

                menu.DisplayMenu();
                input = int.Parse(Console.ReadLine());
            }
            else if (input == 4)
            {
                // Load Entry from File
                dataManager.LoadEntryFromFile();

                menu.DisplayMenu();
                input = int.Parse(Console.ReadLine());
            }
            else if (input > 4) //Quit
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter an integer.");

                menu.DisplayMenu();
                input = int.Parse(Console.ReadLine());
            }
        }



    }


}