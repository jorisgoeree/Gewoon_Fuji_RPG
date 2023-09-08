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

        while (player.CurrentHitPoints > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"Your HP: {player.CurrentHitPoints}/{player.MaximumHitPoints}");
            Console.WriteLine($"{monsterTitleCasing} HP: {monster.CurrentHitPoints}/{monster.MaxHitPoints}");
            
            // Player's turn
            Console.WriteLine();
            Console.WriteLine("It's your turn.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
            player.Attack(monster);
            Console.WriteLine($"{monsterTitleCasing} HP: {monster.CurrentHitPoints}/{monster.MaxHitPoints}");

            // Check if the monster is dead
            if (monster.CurrentHitPoints <= 0)
            {
                Console.WriteLine($"The {monster.Name} is dead, you won!");
                return fightWon = true;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            
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
        Console.WriteLine("You dead my guy, what a pity.");
        return fightWon = false;
    }
}
