using System;

public class Bat : Creature
{
    private int _hunger, _thirst;
    private bool _attackAgain = false;

    public Bat(string name="Bat", int hp=15, int stamina=20, int mana=0, int armor=8) : base (name, hp, stamina, mana, armor)
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
            int damage = random1.Next(1,11);
            Console.WriteLine("A bat bites through your armor.");
            room.GetPlayer().TakeDamage(damage);
            if (_attackAgain == true)
            {
                Random random2 = new Random();
                damage = random2.Next(1,11);
                Console.WriteLine("The bat strikes again.");
                room.GetPlayer().TakeDamage(damage);
            }
        }
    }
    public override void Exert()
    {
        if (GetStamina() >= 10)
        {
            UseStamina(10);
            _attackAgain = true;
        }
    }
    public override void Die()
    {
        TakeDamage(250);
        Console.WriteLine("You defeated a bat!");
    }
}