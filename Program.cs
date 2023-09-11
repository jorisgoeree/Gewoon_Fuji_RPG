using System;

class Program
{
    public static void Main()
    {
        World.PopulateWeapons();
        World.PopulateMonsters();
        World.PopulateQuests();
        World.PopulateLocations();

        // Introduction to the game
        // Ask for a player name

        // int spidersKilled = 0;
        // while (spidersKilled < 3) // Kill three spiders to win the game
        // {
        //     // Inform about current location
        //     // Display the map
        //     // Ask where the player wants to go
        // }

        Monster? monster = World.MonsterByID(3);
        Player player = new(100, World.LocationByID(1), World.WeaponByID(1), 100, "John Doe");
        // SuperAdventure.FightSystem(player, monster);
        SuperAdventure.DisplayLocation(player);
        SuperAdventure.DisplayMap(player);

    }
}
