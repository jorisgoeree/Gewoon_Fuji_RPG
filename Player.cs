public class Player
///test
{
    public const double CritChance = 0.10;
    
    public int CurrentHitPoints;
    public Location CurrentLocation;
    public Weapon CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;

    public Player(int currentHitPoints, Location currentLocation, Weapon currentWeapon, int maximumHitPoints, string name)
    {
        CurrentHitPoints = currentHitPoints;
        CurrentLocation = currentLocation;
        CurrentWeapon = currentWeapon;
        MaximumHitPoints = maximumHitPoints;
        Name = name;
    }

    public void Attack(Monster monster)
    {
        // TODO Implement different types of attack
        // Console.WriteLine("Choose your attack:");
        // Console.WriteLine($"1: {CurrentWeapon.Name}"); // TODO 
        // Console.WriteLine($"2: Lifesteal"); // TODO Decide on amount of dmg
        
        Random rnd = new(); // TODO ??Make this a public const in World.cs??

        double damageDealt = CurrentWeapon.MaxDamage;
        double hitModifier = rnd.NextDouble();
        if (hitModifier <= CritChance){
            damageDealt = (int)(CurrentWeapon.MaxDamage * 1.5);
            Console.WriteLine("Critical Hit!");
        }
        monster.CurrentHitPoints -= (int)damageDealt;
        if (monster.CurrentHitPoints < 0){
            monster.CurrentHitPoints = 0;
        }
        Console.WriteLine($"You dealt {damageDealt} damage.");
    }
}
