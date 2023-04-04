using System;

public class Room
{
    private string _enterMessage, _treasure;
    private int _enemies;
    private bool _explored, _safe;
    private Creature _player;

    private List<Creature> _enemyList = new List<Creature>();

    public Room()
    {
        SetDescription();
        SpawnEnemies();
        Console.WriteLine(_enterMessage);
        Console.WriteLine($"This room has {_enemies} enemies.");
        if (_enemies >0)
        {
            Console.WriteLine("You are in combat!");
        }
    }
        public void RepeatEnter()
    {
        Console.WriteLine(_enterMessage);
        Console.WriteLine($"This room has {_enemies} enemies.");
        if (_enemies >0)
        {
            Console.WriteLine("You are in combat!");
        }
    }
    public bool RoomDisplay()
    {
        Console.WriteLine($"This room has {_enemies} enemies.");
        if (_enemies >0)
        {
            Console.WriteLine("You are in combat!");
            return true;
        }
        else
        {
            return false;
        }
    }


    public void SetDescription()
    {
        Random random = new Random();
        int rand = random.Next(1,9);
        switch (rand)
        {
            case 1: // Boxes
                _enterMessage = ("This room has dozens of dusty crates and boxes pushed into the corners.");
                break;
            case 2: // Fountain
                _safe = true;
                _enterMessage = ("In the center of this room is a running fountain, apparently filtered and pure. It should be safe to rest here.");
                break;
            case 3: // Fireplace
                _enterMessage = ("This area is barren and lightless except for a small fire burning in the center of the room.");
                break;
            case 4: // Beds
                _enterMessage = ("This room was clearly a sleeping chambers at one point - there are double beds pushed to every available inch of wallspace.");
                break;
            case 5: // Barrels
                _enterMessage = ("This room contains some dusty barrels covered in cobwebs. No doubt the rations they hold have rotted inside.");
                break;
            case 6: // Dead Fountain
                _enterMessage = ("This room is empty but for an expired fountain in the center. The small portion of water that remains in it is too dirty to risk drinking.");
                break;
            case 7: // Feast
                _enterMessage = ("This is a large room with a gigantic table stretching from one end to the other. On top of the table is a magnificent feast, apparently freshly prepared.");
                break;
            case 8: // Trap(s)
                _enterMessage = ("This cellar stinks, almost too much to breathe in the air. All around the room are traps and devices yet to be set up around this building.");
                break;
        }
    }
    public int SpawnTreasures()
    {
        Random random = new Random();
        int rand = random.Next(1,13);
        switch (rand)
        {
            case 10: // Medicine
                _treasure = ("You find a small abandoned satchel, holding a potion of restoration inside.");
                return 10;
            case 11: // Equipment
                _treasure = ("You discover a small set of equipment in this room, sure to be an improvement to your own.");
                return 11;
            case 1 | 12: // Gold
                _treasure = ("In a secret crevice in the wall you discover a chest full of valuables worth at least 100 gold pieces.  Score!");
                return 12;
            default: // Nothing
                _treasure = ("There is apparently nothing of worth in this room.");
                return 0;
        }
    }
    public void SpawnEnemies()
    {
        if (_safe != true)
        {
            Random random = new Random();
            int rand = random.Next(0,6);
            switch (rand)
            {
                case 0 | 1:
                    _enemies = 0;
                    break;
                case 2:
                    _enemies = 1;
                    Random random4 = new Random();
                    int determinedEnemies = random4.Next(1,3);
                    if (determinedEnemies == 1)
                    {
                        Zombie zombie = new Zombie();
                        _enemyList.Add(zombie);
                    }
                    else if (determinedEnemies == 2)
                    {
                        Bat bat = new Bat();
                        _enemyList.Add(bat);
                    }
                    break;
                case 3 | 4:
                    Random random1 = new Random();
                    int amount = random1.Next(2,6);
                    _enemies += amount;
                    for (int i=0;i<amount;i++)
                    {
                        Random random5 = new Random();
                        determinedEnemies = random5.Next(1,3);
                        if (determinedEnemies == 1)
                        {
                            Zombie zombie = new Zombie();
                            _enemyList.Add(zombie);
                        }
                        else if (determinedEnemies == 2)
                        {
                            Bat bat = new Bat();
                            _enemyList.Add(bat);
                        }
                    }
                    break;
                case 5:
                    _enemies = 6;
                    Random random3 = new Random();
                    determinedEnemies = random3.Next(1,3);
                    if (determinedEnemies == 1)
                    {
                        Zombie zombie = new Zombie();
                        Zombie zombie2 = new Zombie();
                        Zombie zombie3 = new Zombie();
                        Zombie zombie4 = new Zombie();
                        Zombie zombie5 = new Zombie();
                        Zombie zombie6 = new Zombie();
                        _enemyList.Add(zombie);
                        _enemyList.Add(zombie2);
                        _enemyList.Add(zombie3);
                        _enemyList.Add(zombie4);
                        _enemyList.Add(zombie5);
                        _enemyList.Add(zombie6);
                    }
                    else if (determinedEnemies == 2)
                    {
                        Bat bat = new Bat();
                        Bat bat2 = new Bat();
                        Bat bat3 = new Bat();
                        Bat bat4 = new Bat();
                        Bat bat5 = new Bat();
                        Bat bat6 = new Bat();
                        _enemyList.Add(bat);
                        _enemyList.Add(bat2);
                        _enemyList.Add(bat3);
                        _enemyList.Add(bat4);
                        _enemyList.Add(bat5);
                        _enemyList.Add(bat6);
                    }
                    break;
            }
            // 0-1 = no enemies
            // 2 = one enemy, enemy type = random
            // 3-4 = 1d6-1 (min 2) enemies, each enemy type = random
            // 5 = 6 enemies, each enemy type = same
        }

    }
    public void Explore()
    {
        Console.Clear();
        if (_explored == false)
        {
            Console.WriteLine(_treasure);
            _explored = true;
        }
        else
        {
            Console.WriteLine("You have already explored this room. There is nothing left of significant value.");
        }
    }

    public void DisplayEnemies()
    {
        int number = 0;
        List<Creature> killList = new List<Creature>();
        if (_enemies > 0)
        {
            foreach (Creature enemy in _enemyList)
            {
                killList.Add(enemy);
                if (enemy.GetHP() <= 0)
                {
                    enemy.Die();
                    killList.Remove(enemy);
                }
                else
                {
                    number ++;
                    Console.WriteLine($"{number}.) {enemy.Display()}");
                }
            }
        }
        else
        {
            Console.WriteLine("There are no enemies to fight here.");
        }
        _enemyList = killList;
    }
    public void RemoveEnemies(int amount)
    {
        _enemies -= amount;
        if (_enemies < 0)
        {
            _enemies = 0;
        }
    }
    public void WipeEnemies()
    {
        _enemyList.Clear();
        _enemies = 0;
    }
    public List<Creature> GetEnemyList()
    {
        return _enemyList;
    }
    public int GetEnemyCount()
    {
        return _enemyList.Count;
    }
    public void SpawnBoss()
    {
        Boss boss = new Boss();
        _enemies += 1;
        _enemyList.Add(boss);
        Console.WriteLine("A really powerful enemy appears in the room!");
        Console.WriteLine("You are in a serious combat encounter!");
    }

    public void EnemyTurns()
    {
        foreach (Creature enemy in _enemyList)
        {
            enemy.Attack(this);
        }
    }

    public void AddPlayer(Creature player)
    {
        _player = player;
    }
    public Creature GetPlayer()
    {
        return _player;
    }
}