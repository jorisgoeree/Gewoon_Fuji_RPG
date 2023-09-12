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
        Console.WriteLine("------------Welcome to F.U.J.I!------------");
        Console.WriteLine("Forgotten Universe: Journeys of Illusion\n");
        Console.Write("What doth thou call thee: ");

        string playerName = Console.ReadLine();
        Player player = new(100, World.LocationByID(1), World.WeaponByID(1), 100, playerName);
        player.PlayerInventory.SmallPotions.Add(new Potion("Small potion", "Heals a small amount of HP", 10));
        player.PlayerInventory.LargePotions.Add(new Potion("Large potion", "Heals a Large amount of HP", 20));

        Console.WriteLine($"Good to meet you, {playerName}. Are you ready to start your adventure? (y/n) ");

        string startChoice = Console.ReadLine();
        while (startChoice != "y")
        {
            Console.WriteLine("Ahh, scared I see. Well, no bother, take some time to collect yourself.");
            startChoice = Console.ReadLine();
        }
        //Console.Write("What doth thou call thee: ");

        //string playerName = Console.ReadLine();
        Player player = new(1, World.LocationByID(1), World.WeaponByID(1), 100, "John Doe");

        //Console.WriteLine($"Good to meet you, {playerName}. Are you ready to start your adventure? (y/n) ");

        //string startChoice = Console.ReadLine();
        //while (startChoice != "y")
        //{
        //    Console.WriteLine("Ahh, scared I see. Well, no bother, take some time to collect yourself.");
        //    startChoice = Console.ReadLine();
        //}

        // TODO Explain the goal of the game

        int spidersKilled = 0;
        while (spidersKilled < 3) // Kill three spiders to win the game
        {
            Console.Clear();

            // Inform about current location
            SuperAdventure.DisplayLocation(player);
            Console.WriteLine(player.CurrentLocation.Description);

            // Display the map
            SuperAdventure.DisplayMap(player);

            // Ask where the player wants to go
            SuperAdventure.ChangeLocation(player);

            // Trigger Event at location, Quest or Monster fight
            if (player.CurrentLocation.MonsterLivingHere != null)
            {
                if (!SuperAdventure.FightSystem(player, player.CurrentLocation.MonsterLivingHere))
                {
                    Console.Clear();
                    Console.WriteLine("You wake up in your own bed, was that just a bad dream?");
                    Console.WriteLine("Anyway... Back to the task at hand!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    player.CurrentLocation = World.LocationByID(1);
                }
            }
            else if (player.CurrentLocation.QuestAvailableHere != null) { }
            spidersKilled++;

            else if (player.CurrentLocation.QuestAvailableHere != null)
            {
                if (!player.CurrentLocation.QuestAvailableHere.QuestAccepted)
                {
                    Console.WriteLine("HELLOERFEFFE");
                    SuperAdventure.AcceptQuest(player.CurrentLocation.QuestAvailableHere, player);
                }
            }
            //spidersKilled++;
        }

        // Player (presumably) won the game
        Console.WriteLine($"Congratulations {player.Name}, you have saved everyone and will live happily ever after.");
    }
}
