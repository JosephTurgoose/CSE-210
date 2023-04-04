using System;

public class Player : Creature
{
    private int _hunger, _thirst;
    private bool _fireball, _lightningBolt, _escape, _control, _heal;
    private int _damage = 10;
    private int _gold;
    private bool _escaping = false, _exertAttack = false;
    public Player(string name="Player", int hp=100, int stamina=100, int mana=100,
            int armor=11,bool fireball = false, bool lightningBolt = false, bool escape = false,
            bool control = false, bool heal = false) : base (name, hp, stamina, mana, armor)
    {
        _fireball = fireball;
        _lightningBolt = lightningBolt;
        _escape = escape;
        _control = control;
        _heal = heal;
    }

    ///////////////////////////////////////////////////////////////////////
    public override void Attack(Room room) // Parameters: List of targets
    {
        // Display enemies and read input
        Console.Clear();
        room.DisplayEnemies();
        Console.WriteLine();
        Console.WriteLine("Which enemy would you like to attack?");
        int target = int.Parse(Console.ReadLine()) -1;
        // Randomize hit chance
        Random random = new Random();
        int rand = random.Next(0,21);
        bool hit = false;
        if (rand >= room.GetEnemyList()[target].GetArmor())
        {
            hit = true;
        }
        else
        {
            hit = false;
            Console.WriteLine("Your attack missed the target!");
        }
        // Hit
        if (hit == true)
        {
            Console.Clear();
            // Damage amount
            int damage = 0;
            Random random1 = new Random();
            damage = random1.Next(2, _damage+2);
            // If out of stamina, lower damage.
            if (GetStamina() <= 0)
            {
                damage = 1;
            }
            if (_exertAttack == true)
            {
                damage *= 2;
            }
            // Deal damage to the target enemy.
            room.GetEnemyList()[target].TakeDamage(damage);
            // Hit message
            Console.WriteLine("You strike true on your target, leaving them with a visible injury.");
            // Re-display enemies
            Console.WriteLine("Here are the remaining enemy statistics:");
            room.DisplayEnemies();
        }
        UseStamina(5);
        Console.WriteLine("Enter any key to continue.");
        Console.ReadLine();
        // increase hunger and thirst
        ChangeHunger(_damage);
        ChangeThirst(_armor);

        _exertAttack = false;
        room.EnemyTurns();
    } ////////////////////////////////////////////////////////////////////
    public override void Exert()
    {
        if (GetStamina() >= 25)
        {
            Console.WriteLine("How would you like to exert yourself?");
            Console.WriteLine("1.) Increase next attack damage.");
            Console.WriteLine("2.) Try to Escape.");
            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    _exertAttack = true;
                    break;
                case 2:
                    _escaping = true;
                    break;
            }
            
            UseStamina(25);
            ChangeThirst(15);
            ChangeHunger(13);
        }
        else
        {
            Console.WriteLine("You don't have enough stamina to exert yourself!");
        }
    }

    public override void Die()
    {
        Console.WriteLine("You have perished. Press any key to continue.");
        Console.ReadLine();
        // Quit
    }
    public void ChangeHunger(int amount)
    {
        _hunger += amount;
        if (_hunger >= 100)
        {
            TakeDamage(5);
            Console.WriteLine("Your hunger is too much to handle.");
        }
    }
    public void ChangeThirst(int amount)
    {
        _thirst += amount;
        if (_thirst > 100)
        {
            TakeDamage(5);
            Console.WriteLine("Your thirst is too much to handle.");
        }    }

    public void DisplayStats()
    {
        Console.WriteLine($"HP: {GetHP()}. Stamina: {GetStamina()}. Mana: {GetMana()}. Hunger: {_hunger}. Thirst: {_thirst}. Gold: {_gold}. Armor: {GetArmor()}. Damage: {GetDamage()}.");
    }

    public void IncreaseGold(int amount)
    {
        _gold += amount;
    }

    public bool IsInCombat(Room room)
    {
        if (room.GetEnemyCount() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Rest(Room currentRoom)
    {
        Console.WriteLine("You spend a moment to catch your breath and sustain yourself. You feel much better now.");
        Heal(15);
        RecoverMana(25);
        RecoverStamina(25);
        // Chance to spawn enemies
        Random random = new Random();
        int rand = random.Next(1,21);
        if (rand == 20)
        {
            Console.WriteLine("Enemies prowl about.");
            currentRoom.SpawnEnemies();
        }
    }


    public void CastFireball(Room currentRoom)///////////////////////////////////////////////////////////////
    {
        if (currentRoom.GetEnemyCount() >= 1)
        {
            // Check current mana to make sure there is enough.
            if (GetMana() >= 75)
            {
                // Cast the spell
                currentRoom.WipeEnemies();
                UseMana(75);
                UseStamina(5);
                TakeDamage(5);
                Console.WriteLine("You blast the room with pure energy, destroying all of the enemies but suffer some feedback and become heavily drained.");
                ChangeHunger(10);
                ChangeThirst(10);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You don't have enough mana to cast this spell.");
            }
        }
        else
        {
            Console.WriteLine("That's a bad idea to use without a target...");
        }
        currentRoom.EnemyTurns();
    }
    public void CastLightning(Room currentRoom)////////////////////////////////////////////////////////////
    {
        if (currentRoom.GetEnemyCount() >= 1)
        {
            // Check current mana to make sure there is enough.
            if (GetMana() >= 40)
            {
                // Cast the spell
                UseMana(40);
                Console.WriteLine("You cause lightning to strike in the center of the room.  It hops to each enemy, striking them all.");
                foreach (Creature enemy in currentRoom.GetEnemyList())
                {
                    enemy.TakeDamage(10);
                }
                ChangeHunger(8);
                ChangeThirst(8);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You don't have enough mana to cast this spell.");
            }
        }
        else
        {
            Console.WriteLine("That's a bad idea to use without a target...");
        }
        currentRoom.EnemyTurns();
    }
    public void CastControl(Room currentRoom)//////////////////////////////////////////////////////////////
    {
        if (currentRoom.GetEnemyCount() >= 1)
        {
            // Check current mana to make sure there is enough.
            if (GetMana() >= 30)
            {
                currentRoom.DisplayEnemies();
                int target = int.Parse(Console.ReadLine())-1;

                UseMana(30);
                Console.WriteLine("You take possession of the target's mind for a small moment, leaving them dazed and effectively lost from the fight.");
                currentRoom.GetEnemyList()[target].Die();
                ChangeHunger(6);
                ChangeThirst(6);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You don't have enough mana to cast this spell.");
            }
        }
        else
        {
            Console.WriteLine("That's a bad idea to use without a target...");
        }
        currentRoom.EnemyTurns();

    }
    public void CastHeal(Room currentRoom)////////////////////////////////////////////
    {
        if (GetMana() >= 25)
        {
            Random random = new Random();
            int rand = random.Next(10,36);
            Heal(rand);
            Console.WriteLine($"You feel more refreshed and pure after being healed for {rand.ToString()} points.");
        }
        else
        {
            Console.WriteLine("You don't have enough mana to cast that spell!");
        }
        currentRoom.EnemyTurns();
    }
    public bool CastEscape()//////////////////////////////////////////
    {
        if (GetMana() >= 50)
        {
            UseMana(50);
            Console.WriteLine("You create a distraction and disengage from combat.");
            _escaping = true;
            return true;
        }
        else
        {
            Console.WriteLine("You don't have enough mana to cast that spell!");
            _escaping = false;
            return false;
        }
    }
    public bool IsEscaping()
    {
        if (_escaping == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetEscaping(bool answer)
    {
        _escaping = answer;
    }

    public void DisplaySpells()
    {
        if (_fireball == true | _lightningBolt == true | _control == true | _heal == true | _escape == true)
        {
            List<string> spells = new List<string>();
            if (_fireball == true)
            {
                spells.Add("1.) Fireball");
            }
            if (_lightningBolt == true)
            {
                spells.Add("2.) Lightning Bolt");
            }
            if (_control == true)
            {
                spells.Add("3.) Control Enemy");
            }
            if (_heal == true)
            {
                spells.Add("4.) Heal Self");
            }
            if (_escape == true)
            {
                spells.Add("5.) Escape");
            }

            Console.WriteLine("0.) No Spell");
            foreach (string spell in spells)
            {
                Console.WriteLine($"{spell}");
            }
        }
        else
        {
            Console.WriteLine("You do not know any spells.");
        }
    }
    public bool KnowSpell(int spellNumber)
    {
        switch (spellNumber)
        {
            case 1:
                return _fireball;
            case 2:
                return _lightningBolt;
            case 3:
                return _control;
            case 4:
                return _heal;
            case 5:
                return _escape;
            default:
                return false;
        }
    }


/////////////////////////////////


}
