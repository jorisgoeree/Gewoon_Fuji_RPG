using System.Dynamic;

public class Player
{
    public const double CritChance = 0.10;

    public int CurrentHitPoints;
    public Location CurrentLocation;
    public Weapon CurrentWeapon;
    public Inventory PlayerInventory;
    public int MaximumHitPoints;
    public string Name;
    public int CompletedQuests { get; private set;}
    public Player(int currentHitPoints, Location currentLocation, Weapon currentWeapon, int maximumHitPoints, string name)
    {
        CurrentHitPoints = currentHitPoints;
        CurrentLocation = currentLocation;
        CurrentWeapon = currentWeapon;
        MaximumHitPoints = maximumHitPoints;
        Name = name;
        PlayerInventory = new Inventory();
    }

    public int Attack(Monster monster)
    {
        // TODO Implement different types of attack
        // Console.WriteLine("Choose your attack:");
        // Console.WriteLine($"1: {CurrentWeapon.Name}"); // TODO
        // Console.WriteLine($"2: Lifesteal"); // TODO Decide on amount of dmg

        Random rnd = new();

        double damage = CurrentWeapon.MaxDamage;
        double hitModifier = rnd.NextDouble();
        if (hitModifier <= CritChance)
        {
            damage = (int)(CurrentWeapon.MaxDamage * 1.5);
            Console.WriteLine("Critical Hit!");
        }
        monster.CurrentHitPoints -= (int)damage;
        if (monster.CurrentHitPoints < 0)
        {
            monster.CurrentHitPoints = 0;
        }
        return (int)damage;
    }

    public void DrinkSmallPotion()
    {
        if (PlayerInventory.SmallPotions.Count > 0)
        {
            int regenAmount = PlayerInventory.SmallPotions[0].RegenAmount;

            int newHp = CurrentHitPoints + regenAmount;

            if (newHp > MaximumHitPoints)
            {
                newHp = MaximumHitPoints;
            }

            CurrentHitPoints = newHp;
            PlayerInventory.RemoveSmallPotion();
            Console.WriteLine($"Drinks small potion GLUP GLUP\nHP added: {regenAmount}\nCurrent health: {CurrentHitPoints}");
        }
        else
        {
            Console.WriteLine("You do not have this potion in your inventory!");
        }
    }

    public void DrinkLargePotion()
    {
        if (PlayerInventory.LargePotions.Count > 0)
        {
            int regenAmount = PlayerInventory.LargePotions[0].RegenAmount;

            int newHp = CurrentHitPoints + regenAmount;

            if (newHp > MaximumHitPoints)
            {
                newHp = MaximumHitPoints;
            }

            CurrentHitPoints = newHp;
            PlayerInventory.RemoveLargePotion();
            Console.WriteLine($"Drinks potion GLUP GLUP \nHP added: {regenAmount}\nCurrent health: {CurrentHitPoints}");
        }
        else
        {
            Console.WriteLine("You do not have this potion in your inventory!");
        }
    }

    public void CompleteQuest(Quest quest)
    {
        if (quest.QuestAccepted)
        {
            quest.QuestAccepted = false;
            CompletedQuests++;
        }
    }
}
