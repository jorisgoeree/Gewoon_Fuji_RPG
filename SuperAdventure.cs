using System.Numerics;

static class SuperAdventure
{
    public const double FlightSuccesRate = 0.33; // 33% chance of succes

    public static Potion smallPot = new Potion("Small potion", "Heals a Small amount of HP", 10);
    public static Potion largePot = new Potion("Large potion", "Heals a Large amount of HP", 20);

    public static bool FightSystem(Player player, Monster monster)
    {
        bool fightWon;
        int damageDealt;
        int damageReceived;
        string monsterTitleCasing = char.ToUpper(monster.Name[0]) + monster.Name.Substring(1); // Used for displaying the name during the fight

        Console.Clear();
        Console.WriteLine($"You encountered a {monster.Name}.");
        Console.WriteLine("What do you want to do?");
        Console.Write("1: Fight\n2: Run Away ");

        // Parse the player's choice
        int fightChoice = 0;
        bool validChoice = false;
        while (!validChoice)
        {
            string? fightChoiceString = Console.ReadLine();
            validChoice = int.TryParse(fightChoiceString, out fightChoice);
            if (!validChoice)
            {
                Console.WriteLine("Invalid input, try again.");
            }
        }

        Console.Clear();

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
            else
            {
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
            Console.WriteLine($"Your HP: {player.CurrentHitPoints}/{player.MaximumHitPoints}");
            Console.WriteLine($"{monsterTitleCasing} HP: {monster.CurrentHitPoints}/{monster.MaxHitPoints}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            // Player's turn
            Console.WriteLine("It's your turn.");
            Console.WriteLine("What do you want to do?\n1: Attack\n2: Use an item");
            string fightMenuChoice = Console.ReadLine();
            Console.Clear();

            // Player chose to use an item
            if (fightMenuChoice == "2")
            {
                int smallCount = player.PlayerInventory.SmallPotions.Count();
                int largeCount = player.PlayerInventory.LargePotions.Count();

                Console.WriteLine($"You have:\n{smallCount} Small Potions\n{largeCount} Large Potions\n");
                Console.WriteLine("What kind of potion do you want to drink?\n1: Small Potion\n2: Large Potion");

                string choicePotion = Console.ReadLine();

                if (choicePotion == "1")
                {
                    player.DrinkSmallPotion();
                }
                else if (choicePotion == "2")
                {
                    player.DrinkLargePotion();
                }
            }
            else // Player choose to attack
            {
                damageDealt = player.Attack(monster);
                Console.WriteLine($"You dealt {damageDealt} damage.");
                Console.WriteLine($"{monsterTitleCasing} HP: {monster.CurrentHitPoints}/{monster.MaxHitPoints}");

                // Check if the monster is dead
                if (monster.CurrentHitPoints <= 0)
                {
                    Console.WriteLine($"The {monster.Name} is dead, you won!");

                    Random rnd = new Random();

                    double potionDropChance = rnd.NextDouble();

                    if (potionDropChance <= 0.25)
                    {
                        player.PlayerInventory.LargePotions.Add(largePot);
                        Console.WriteLine("The monster dropped a large potion!");
                    }
                    else if (potionDropChance <= 0.5)
                    {
                        player.PlayerInventory.SmallPotions.Add(smallPot);
                        Console.WriteLine("The monster dropped a small potion!");
                    }

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    return fightWon = true;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }

            // Monster's turn
            Console.WriteLine($"{monsterTitleCasing}'s turn");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            damageReceived = monster.Attack(player);
            Console.WriteLine($"The {monster.Name} hits you for {damageReceived} damage.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        Console.Clear();
        Console.WriteLine("You died!");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        return fightWon = false;
    }

    public static void ChangeLocation(Player player)
    {
        Console.WriteLine("Where do you want to go (N/E/S/W)? \nPress 'Q to leave the game.");
        string locationToGo = Console.ReadLine().ToUpper();
        Location currentLocation = player.CurrentLocation;
        switch (locationToGo)
        {
            case "N":
                if (currentLocation.LocationToNorth != null)
                    player.CurrentLocation = currentLocation.LocationToNorth;
                else
                {
                    Console.WriteLine("Can't move to this location");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                break;
            case "E":
                if (currentLocation.LocationToEast != null)
                    player.CurrentLocation = currentLocation.LocationToEast;
                else
                {
                    Console.WriteLine("Can't move to this location");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                break;
            case "S":
                if (currentLocation.LocationToSouth != null)
                    player.CurrentLocation = currentLocation.LocationToSouth;
                else
                {
                    Console.WriteLine("Can't move to this location");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                break;
            case "W":
                if (currentLocation.LocationToWest != null)
                    player.CurrentLocation = currentLocation.LocationToWest;
                else
                {
                    Console.WriteLine("Can't move to this location");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                break;

             case "Q":
                Console.WriteLine("Are you sure you want to leave the game? (yes/no) You will lose your progess.");
                string? ConfirmExit = Console.ReadLine();
                if (ConfirmExit == "yes")
                {
                    Console.WriteLine("You quit.");
                    break;
                }
                else
                {
                    ChangeLocation(player);
                }
            default:
                {
                    Console.WriteLine("Can't move to this location");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
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

    public static void AcceptQuest(Quest quest, Player player)
    {
        if (quest.ID == 2) // Clear the farmers field
        {
            Console.Clear();
            SuperAdventure.DisplayLocation(player);
            Console.WriteLine(player.CurrentLocation.Description);

            Console.WriteLine();
            Console.WriteLine("The farmer is wildly waving at you.");
            Console.WriteLine("You decide to go over and hear him out.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Console.Clear();
            SuperAdventure.DisplayLocation(player);
            Console.WriteLine(player.CurrentLocation.Description);
            Console.WriteLine();
            Console.WriteLine("It's time for me to harvest the crops, but it's too dangerous to do any work right now.");
            Console.WriteLine("There's snakes all over the fields, please take care of them for me.");
            Console.WriteLine("The fields are just to the west of here.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Quest accepted: {player.CurrentLocation.QuestAvailableHere.Description} 0/3");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            player.CurrentLocation.QuestAvailableHere.QuestAccepted = true;
        }
        else if (quest.ID == 1) 
        {
            Console.Clear();
            SuperAdventure.DisplayLocation(player);
            Console.WriteLine(player.CurrentLocation.Description);

            Console.WriteLine();
            Console.WriteLine("The alchemist has apparently gone mad, throwing his glass bottles around and screaming like a mad man.");
            Console.WriteLine("You fear for your own safety, but yell at him despite that.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Console.Clear();
            SuperAdventure.DisplayLocation(player);
            Console.WriteLine(player.CurrentLocation.Description);
            Console.WriteLine();
            Console.WriteLine("WHAT DO YOU WANT?! Can't you see I don't have any potions to sell right now.");
            Console.WriteLine("Those damn rats have chewed up all my herbs.");
            Console.WriteLine("But wait.. Maybe you can go and take care of them for me?");
            Console.WriteLine("My garden is a small walk north of here, can't miss it.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Quest accepted: {player.CurrentLocation.QuestAvailableHere.Description} 0/3");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            player.CurrentLocation.QuestAvailableHere.QuestAccepted = true;
        }
        else if (quest.ID == 3)
        {
            Console.Clear();
            SuperAdventure.DisplayLocation(player);
            Console.WriteLine(player.CurrentLocation.Description);

            Console.WriteLine();
            Console.WriteLine("The guard is slightly hunched over, and you hear a faint muttering a few words every now and then.");
            Console.WriteLine("'WAKE UP!!', You yell at the top of your lungs.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Console.Clear();
            SuperAdventure.DisplayLocation(player);
            Console.WriteLine(player.CurrentLocation.Description);
            Console.WriteLine();
            Console.WriteLine("Huh, what!? NO, NOO, I wasn't sleeping. Just thinking really hard!");
            Console.WriteLine("But hey, while you're here, do me a favor will ya.");
            Console.WriteLine("There's some spiders to east of here, collect some of their silk and I'll make it worth your while.");
            Console.WriteLine("What!? Naahh, you'll be fine. They're just a little *AHUM* poisonous *AHUM*, nothing to worry about.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Quest accepted: {player.CurrentLocation.QuestAvailableHere.Description} 0/3");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            player.CurrentLocation.QuestAvailableHere.QuestAccepted = true;
        }
    }
}
