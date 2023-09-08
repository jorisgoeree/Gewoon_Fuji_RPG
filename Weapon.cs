public class Weapon
{
    public int ID;
    public string Name;
    public double MaxDamage;

    public Weapon(int weaponId, string name, int maxDamage)
    {
        ID = weaponId;
        Name = name;
        MaxDamage = maxDamage;
    }
}
