using System;

public abstract class Room
{
    private string _enterMessage;
    private int _doors;

    public Room()
    {
        SetDescription();
        SpawnTreasures();
        SpawnEnemies();
        SpawnDoors();
        Console.WriteLine($"This room has {_doors.ToString()} doors.");
    }

    public void SetDescription()
    {
        Random random = new Random();
        int rand = random.Next(1,9);
        switch (rand)
        {
            case 1: // Boxes
                break;
            case 2: // Fountain
                break;
            case 3: // Fireplace
                break;
            case 4: // Beds
                break;
            case 5: // Barrels
                break;
            case 6: // Fountain
                break;
            case 7: // Feast
                break;
            case 8: // Trap(s)
                break;
        }
    }
    public void SpawnTreasures()
    {
        Random random = new Random();
        int rand = random.Next(1,13);
        switch (rand)
        {
            case 10: // Medicine
                break;
            case 11: // Equipment
                break;
            case 12: // Gold
                break;
            default: // Nothing
                break;
        }
    }
    public void SpawnEnemies()
    {
        Random random = new Random();
        int rand = random.Next(0,6);
        // 0-1 = no enemies
        // 2 = one enemy, enemy type = random
        // 3-4 = 1d6-1 (min 2) enemies, each enemy type = random
        // 5 = 6 enemies, each enemy type = same
    }
    public void SpawnDoors()
    {
        Random random = new Random();
        int rand = random.Next(1,5);
        _doors = rand;
    }
}