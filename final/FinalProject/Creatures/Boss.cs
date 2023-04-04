using System;

public class Boss : Creature
{
    private int _hunger, _thirst;
    private Room currentRoom;

    public Boss(string name="Boss", int hp=100, int stamina=50, int mana=50, int armor=14) : base (name, hp, stamina, mana, armor)
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
        int rand = random.Next(1,22);
        if (rand >= room.GetPlayer().GetArmor())
        {
            Random random1 = new Random();
            int damage = random1.Next(1,31);
            Console.WriteLine("The boss strikes successfully at you, almost knocking you off your feet.");
            room.GetPlayer().TakeDamage(damage);
        }
    }
    public override void Exert()
    {
        if (GetStamina() >= 10)
        {
            UseStamina(10);
            Heal(15);
            Console.WriteLine("The boss gets riled up and roars with new energy.");
        }
    }
    public override void Die()
    {
        Console.WriteLine("You have defeated the boss of this dungeon! You retrieve his key and escape!");
        Thread.Sleep(1000);
        Console.WriteLine("You win!");
        System.Environment.Exit(1);
    }
}