using System;

class Program
{
    static void Main(string[] args)
    {
        // Assign each activity its variables
        Breathing breathing = new Breathing("breathing activity", "This is the breathing activity");
        Listing listing = new Listing("listing activity", "This is the listing activity");
        Reflecting reflecting = new Reflecting("reflecting activity", "This is the reflecting activity");

        /*
        Menu:
        What would you like to do?
        1: Breathing
        2: Listing
        3: Reflecting
        4: Quit

        Activate the appropriate activity with its PlayActivity() method
        Report a score or some other datapoint to the user on how well they did, which for breathing is always 100%, assuming they did the activity

        Call the menu again
        Continue this loop
        */
    }

}