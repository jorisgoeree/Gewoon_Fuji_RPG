public class Monster
{
    public int ID;
    public string Name;
    public int MaxHitPoints;
    public int MaxDamage;
    public int CurrentHitPoints;
    public const double CritChance = 0.20;

    public Monster(int id, string name, int maxDamage, int maxHitPoints, int currentHitPoints)
    {
        ID = id;
        Name = name;
        MaxHitPoints = maxHitPoints;
        MaxDamage = maxDamage;
        CurrentHitPoints = currentHitPoints;
        
    }

    public int Attack(Player player)
    {
        int damage = MaxDamage;
        Random rnd = new();
        double hitModifier = rnd.NextDouble();
        if (hitModifier < CritChance)
        {
            Console.WriteLine("Critical Hit!");
            damage = MaxDamage * 2;
            player.CurrentHitPoints -= damage;
        }
        player.CurrentHitPoints -= damage;
        return damage;
    }
}
