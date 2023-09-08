public class Monster
{
    public int ID;
    public string Name;
    public int MaxHitPoints;
    public int MaxDamage;
    public int CurrentHitPoints;

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
        // TODO Implement crit system
        player.CurrentHitPoints -= MaxDamage;
        return MaxDamage;
    }
}
