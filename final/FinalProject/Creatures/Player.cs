using System;

public class Player : Creature
{
    private int _hunger, _thirst;
    private bool _fireball, _lightningBolt, _escape, _control, _heal;
    private int _damage = 6;
    private int _gold;
    private bool _inCombat = false;
    public Player(string name="Player", int hp=100, int stamina=50, int mana=50,
            int armor=11,bool fireball = false, bool lightningBolt = false, bool escape = false,
            bool control = false, bool heal = false) : base (name, hp, stamina, mana, armor)
    {
        _fireball = fireball;
        _lightningBolt = lightningBolt;
        _escape = escape;
        _control = control;
        _heal = heal;
    }

    public override int Attack() // Parameters: List of targets
    {
        // Print out list of targets
        // Read keys to see which target to attack
        // Randomize hit chance
        // If hit, randomize and return damage, then give a hit! message
        // If no hit, return 0 damage, then give a miss! message
        // increase hunger and thirst
        return 0;
    }
    public override void Exert()
    {
        // How would you like to exert yourself?
        // 1 - Travel Twice
        // 2 - Attack Twice
        
        // Remove Stamina
        // increase hunger and thirst
    }

    public override void Die()
    {
        // Display Death Message
        // Any button to continue
        // Quit
    }
    public void ChangeHunger(int amount)
    {
        _hunger += amount;
        // if too hungry, take damage
    }
    public void ChangeThirst(int amount)
    {
        _thirst += amount;
        // if too thirsty, take damage
    }

    public void DisplayStats()
    {
        Console.WriteLine($"HP: {GetHP()}. Stamina: {GetStamina()}. Mana: {GetMana()}. Hunger: {_hunger}. Thirst: {_thirst}.  Gold: {_gold}");
    }

    public void IncreaseGold(int amount)
    {
        _gold += amount;
    }

    public bool InCombat()
    {
        return _inCombat;
    }
}
