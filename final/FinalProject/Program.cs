using System;

class Program
{
    static void Main(string[] args)
    {
        // Customization & startup __________________________________________________________________
        List<string> options = new List<string>{"1 - HP up - 1 point",
                                                "2 - Stamina up - 1 point",
                                                "3 - Mana up - 1 point",
                                                "4 - Better Armor - 1 point",
                                                "5 - Better Weapon Damage - 1 point",
                                                "6 - Spell: Fireball - 1 point",
                                                "7 - Spell: Lightning Bolt - 1 point",
                                                "8 - Spell: Escape - 2 points",
                                                "9 - Spell: Control Enemy - 2 points",
                                                "10 - Spell: Heal Self - 2 points"};

        Console.Clear();
        int points = 10;
        Console.WriteLine("Welcome to The Game! Please enter your name.");
        string name = Console.ReadLine();
        int health = 100, stamina = 50, mana = 50, armor =11, damage = 6;
        bool fireball, lightningBolt, escape, control, heal;
        Console.WriteLine("Please select your features and equipment (Type their feature number in order to add it).");
        while (points > 0)
        {
            foreach (string feature in options)
            Console.WriteLine(feature);
            Console.WriteLine("0: Done");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case ("1"):
                    health += 20;
                    points -= 1;
                    break;
                case ("2"):
                    stamina += 20;
                    points -= 1;
                    break;
                case ("3"):
                    mana += 20;
                    points -= 1;
                    break;
                case ("4"):
                    armor += 1;
                    points -= 1;
                    break;
                case ("5"):
                    damage += 3;
                    points -= 1;
                    break;
                case ("6"):
                    fireball = true;
                    points -= 1;
                    options.Remove("6 - Spell: Fireball - 1 point");
                    break;
                case ("7"):
                    lightningBolt = true;
                    points -= 1;
                    options.Remove("7 - Spell: Lightning Bolt - 1 point");
                    break;
                case ("8"):
                    escape = true;
                    points -= 2;
                    options.Remove("8 - Spell: Escape - 2 points");
                    break;
                case ("9"):
                    control = true;
                    points -= 2;
                    options.Remove("9 - Spell: Control Enemy - 2 points");
                    break;
                case ("10"):
                    heal = true;
                    points -= 2;
                    options.Remove("10 - Spell: Heal Self - 2 points");
                    break;
            }
            if (answer == "0")
            {
                break;
            }
        }
        Player player = new Player(name, health, stamina, mana, armor, fireball=true, lightningBolt=true, escape=true, control=true, heal=true);
        player.SetDamage(damage);


        // Activity ________________________________________________________________________
        // Check Stats
        // Attack/Spell
        // Look Around / Explore
        // Rest
        // Travel
        Console.Clear();
        string input = "";
        while (input != "7")
        {
            Console.WriteLine("What would you like to do?");
            input = Console.ReadLine();
            switch (input)
            {
                case ("1"): // Check Stats
                    Console.Clear();
                    player.DisplayStats();
                    break;
                case ("2"): // Attack
                    Console.WriteLine("There are no monsters here.");
                    break;
                case ("3"): // Explore
                    Console.WriteLine("There's a chest! Inside you find 5 pieces of gold!");
                    player.IncreaseGold(5);
                    break;
                case ("4"): // Rest
                    Console.WriteLine("You feel well-rested.");
                    break;
                case ("5"): // Travel
                    Console.WriteLine("You enter the next room");
                    break;
                case ("6"):
                    break;
            }
        }

    }



}