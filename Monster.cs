public class Monster
{
    public int ID;
    public string Name;
    public int MaxHitPoints;
    public int MaxDamage;
    public int UnknownVariable; // TO DO figure out what to use this variable for

    public Monster(int id, string name, int maxDamage, int maxHitPoints, int unknownVariable)
    {
        ID = id;
        Name = name;
        MaxHitPoints = maxHitPoints;
        MaxDamage = maxDamage;
        UnknownVariable = unknownVariable;
        
    }
}
