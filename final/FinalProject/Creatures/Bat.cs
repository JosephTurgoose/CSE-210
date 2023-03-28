using System;

public class Bat : Creature
{
    private int _hunger, _thirst;

    public Bat(string name="Bat", int hp=15, int stamina=20, int mana=0, int armor=11) : base (name, hp, stamina, mana, armor)
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