static class SuperAdventure
{
    public const double FlightSuccesRate = 0.33; // 33% chance of succes
    
    public static bool FightSystem(Player player, Monster monster)
    {
        bool fightWon;
        int damageDealt;
        int damageReceived;
        string monsterTitleCasing = char.ToUpper(monster.Name[0]) + monster.Name.Substring(1); // Used for displaying the name during the fight
        
        Console.WriteLine($"You encountered a {monster.Name}.");
        Console.WriteLine("What do you want to do?");
        Console.Write("1: Fight\n2: Run Away ");
        
        // Parse the player's choice
        int fightChoice = 0;
        bool validChoice = false;
        while(!validChoice)
        {
            string? fightChoiceString = Console.ReadLine();
            validChoice = int.TryParse(fightChoiceString, out fightChoice);
            if (!validChoice){
                Console.WriteLine("Invalid input, try again.");
            }
        }
        
        // If the player chose escape, success is based on chance
        if (fightChoice == 2)
        {
            Random rnd = new();
            double flightChance = rnd.NextDouble();
            if (flightChance < FlightSuccesRate)
            {
                Console.WriteLine($"You successfully escaped the {monster.Name}.");
                return fightWon = true; // TODO not useful to have a true if escaped
            }
            else{
                // Monster gets first hit if failed escape attempt
                damageReceived = monster.Attack(player);
                Console.WriteLine($"You fell down while trying to run away, the {monster.Name} attacks you for {damageReceived} damage.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                
            }
        }
        // If the player chose attack, or failed escape attempt
        while (player.CurrentHitPoints > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"Your HP: {player.CurrentHitPoints}/{player.MaximumHitPoints}");
            Console.WriteLine($"{monsterTitleCasing} HP: {monster.CurrentHitPoints}/{monster.MaxHitPoints}");

            // Player's turn
            Console.WriteLine();
            Console.WriteLine("It's your turn.");
            Console.WriteLine("What do you want to do?\n1: Attack\n2: Use an item");
            string fightMenuChoice = Console.ReadLine();

            // Player chose to use an item
            if (fightMenuChoice == "2")
            {
                //Player.UseAnItem(); // TODO Link up this method with items.
            }
            else // Player choose to attack
            {
                Console.WriteLine();
                damageDealt = player.Attack(monster);
                Console.WriteLine($"You dealt {damageDealt} damage.");
                Console.WriteLine($"{monsterTitleCasing} HP: {monster.CurrentHitPoints}/{monster.MaxHitPoints}");

                // Check if the monster is dead
                if (monster.CurrentHitPoints <= 0)
                {
                    Console.WriteLine($"The {monster.Name} is dead, you won!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    return fightWon = true;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

            // Monster's turn
            Console.WriteLine();
            Console.WriteLine($"{monsterTitleCasing}'s turn");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            damageReceived = monster.Attack(player);
            Console.WriteLine();
            Console.WriteLine($"The {monster.Name} hits you for {damageReceived} damage.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        Console.WriteLine("You died!");
        return fightWon = false;
    }

    public static void ChangeLocation(Player player)
    {
        Console.WriteLine("Where do you want to go (N/E/S/W)?");
        string locationToGo = Console.ReadLine().ToUpper();
        Location currentLocation = player.CurrentLocation;
        switch (locationToGo)
        {
            case "N":
                if (currentLocation.LocationToNorth != null)
                    player.CurrentLocation = currentLocation.LocationToNorth;
                else
                    Console.WriteLine("Can't move to this location");
                break;
            case "E":
                if (currentLocation.LocationToEast != null)
                    player.CurrentLocation = currentLocation.LocationToEast;
                else
                    Console.WriteLine("Can't move to this location");
                break;
            case "S":
                if (currentLocation.LocationToSouth != null)
                    player.CurrentLocation = currentLocation.LocationToSouth;
                else
                    Console.WriteLine("Can't move to this location");
                break;
            case "W":
                if (currentLocation.LocationToWest != null)
                    player.CurrentLocation = currentLocation.LocationToWest;
                else
                    Console.WriteLine("Can't move to this location");
                break;
            default:
                Console.WriteLine("Can't move to this location");
                break;
        }
    }

    public static void DisplayMap(Player player)
    {
        string map = player.CurrentLocation.ID switch
        {
            1 => "    T\n    |\n    H\n\n",
            2 => "    A\n    |\nF---T---G\n    |\n    H",
            3 => "     \n     \nT---G---B\n\n",
            4 => "    P\n    |\n    A\n    |\n    T",
            5 => "     \n     \n    P\n    |\n    A",
            6 => "     \n     \nV---F---T\n\n",
            7 => "     \n     \n    V---F\n\n",
            8 => "     \n     \nG---B---S\n\n",
            9 => "     \n     \nB---S\n\n"
        };
        Console.WriteLine(map);
    }

    public static void DisplayLocation(Player player) 
    {
        Console.WriteLine($"Current Location: {player.CurrentLocation.Name}");
    }
}
