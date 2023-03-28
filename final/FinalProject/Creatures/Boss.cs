using System;

public class Boss : Creature
{
    private int _hunger, _thirst;

    public Boss(string name="Boss", int hp=100, int stamina=50, int mana=50, int armor=15) : base (name, hp, stamina, mana, armor)
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

    public void SummonMinions()
    {
        
    }
}