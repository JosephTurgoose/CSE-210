using System;

public class Zombie : Creature
{
    private int _hunger, _thirst;

    public Zombie(string name="Zombie", int hp=25, int stamina=15, int mana=5, int armor=10) : base (name, hp, stamina, mana, armor)
    {

    }

    public override int Attack()
    {
        return 0;
    }
    public override void Exert()
    {

    }
    public override void Die()
    {
        // Display Death Message
    }
}