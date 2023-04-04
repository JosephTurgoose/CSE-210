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
        int health = 100, stamina = 100, mana = 100, armor =11, damage = 10;
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
        Room currentRoom = new Room();
        List<Room> rooms = new List<Room>();
        rooms.Add(currentRoom);
        currentRoom.WipeEnemies();
        currentRoom.AddPlayer(player);

        Console.Clear();
        string input = "";
        while (input != "8")
        {
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1.) Check Stats");
            Console.WriteLine("2.) Attack");
            Console.WriteLine("3.) Cast a spell");
            Console.WriteLine("4.) Search the Room");
            Console.WriteLine("5.) Rest");
            Console.WriteLine("6.) Travel");
            Console.WriteLine("7.) Exert yourself");
            Console.WriteLine("8.) Quit");
            input = Console.ReadLine();
            switch (input)
            {
                case ("1"): // Check Stats
                    Console.Clear();
                    player.DisplayStats();
                    break;
                case ("2"): // Attack
                    Console.Clear();
                    if (player.IsInCombat(currentRoom) == true)
                    {
                        player.Attack(currentRoom);
                    }
                    else
                    {
                        Console.WriteLine("There are no monsters here to fight.");
                    }
                    break;
                case ("3"): // Cast a Spell
                    Console.Clear();
                    Console.WriteLine("Select a spell to cast.");
                    player.DisplaySpells();
                    int spellToCast = int.Parse(Console.ReadLine());
                    if (player.KnowSpell(spellToCast) == true)
                    {
                        switch (spellToCast)
                        {
                            case 1:
                                player.CastFireball(currentRoom);
                                break;
                            case 2:
                                player.CastLightning(currentRoom);
                                break;
                            case 3:
                                player.CastControl(currentRoom);
                                break;
                            case 4:
                                player.CastHeal(currentRoom);
                                break;
                            case 5:
                                player.CastEscape();
                                break;
                        }
                    }
                    break;
                case ("4"): // Search
                    Console.Clear();
                    if (currentRoom.SpawnTreasures() == 1 | currentRoom.SpawnTreasures() == 12)
                    {
                        player.IncreaseGold(138);
                    }
                    else if (currentRoom.SpawnTreasures() == 10)
                    {
                        player.Heal(10);
                        player.RecoverMana(10);
                        player.RecoverStamina(10);
                        player.ChangeThirst(-5);
                    }
                    else if (currentRoom.SpawnTreasures() == 11)
                    {
                        damage += 1;
                        armor += 1;
                        player.SetDamage(damage);
                        player.SetArmor(armor);
                    }
                    currentRoom.Explore();
                    break;
                case ("5"): // Rest
                    Console.Clear();
                    player.Rest(currentRoom);
                    break;
                case ("6"): // Travel
                    Console.Clear();
                    bool isNewRoom = false;
                    // Check if in combat.  If yes, must use escape spell to travel.  If no, continue.
                    if (player.IsInCombat(currentRoom) == true & player.IsEscaping() == false)
                    {
                        Console.WriteLine("You can't travel in combat unless you exert yourself or use the Escape spell!");
                    }
                    else
                    {
                        Console.WriteLine("Travel to the next room (1) or the previous room (2)?");
                        int answer = int.Parse(Console.ReadLine());
                        switch (answer)
                        {
                            case 1:
                                Console.Clear();
                                if (rooms.IndexOf(currentRoom) < rooms.Count-1)
                                {
                                    currentRoom = rooms[rooms.IndexOf(currentRoom)+1]; // Move forward to a visited room
                                }
                                else // if currentRoom is at the highest index, move forward to a new room.
                                {
                                    Room newRoom = new Room();
                                    rooms.Add(newRoom);
                                    currentRoom = newRoom;
                                    currentRoom.AddPlayer(player);
                                    if (rooms.IndexOf(currentRoom) == 10)
                                    {
                                        currentRoom.SpawnBoss();
                                        
                                    }
                                    isNewRoom = true;
                                }
                                break;
                            case 2:
                                Console.Clear();
                                if (rooms.IndexOf(currentRoom) > 0)
                                {
                                    currentRoom = rooms[rooms.IndexOf(currentRoom)-1]; // Move backwards to a visited room
                                }
                                else
                                {
                                    Console.WriteLine("The exit is locked! You can't leave the building!");
                                }
                                break;
                        }
                        if (rooms.IndexOf(currentRoom) > 0)
                        {
                            if (isNewRoom != true)
                            {
                                currentRoom.RepeatEnter();
                            }
                        }
                        player.SetEscaping(false);
                    }
                    break;
                case ("7"): // Exert
                    Console.Clear();
                    player.Exert();
                    break;
            }
        }
    }
}