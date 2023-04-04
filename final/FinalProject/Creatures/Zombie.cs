using System;

public class Zombie : Creature
{
    private int _hunger, _thirst;

    public Zombie(string name="Zombie", int hp=25, int stamina=15, int mana=5, int armor=11) : base (name, hp, stamina, mana, armor)
    {

    }

    public override void Attack(Room room)
    {
        Random exertChance = new Random();
        int chance = exertChance.Next(1,11);
        if (chance == 10)
        {
            Exert();
        }

        Random random = new Random();
        int rand = random.Next(1,21);
        if (rand >= room.GetPlayer().GetArmor())
        {
            Random random1 = new Random();
            int damage = random1.Next(1,16);
            Console.WriteLine("A zombie mauls you. Not very pleasant.");
            room.GetPlayer().TakeDamage(damage);
        }
    }
    public override void Exert()
    {
        if (GetStamina() > 15)
        {
            UseStamina(15);
            Heal(5);
            Console.WriteLine("A zombie heals itself a little.");
        }
    }
    public override void Die()
    {
        TakeDamage(250);
        Console.WriteLine("You defeated a zombie!");
    }
}