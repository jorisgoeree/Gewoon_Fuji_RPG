using System.Collections;

public class Inventory
{
    public List<Potion> SmallPotions;

    public List<Potion> LargePotions;

    public Inventory()
    {
        SmallPotions = new List<Potion>();
        LargePotions = new List<Potion>();
    }

    public void AddSmallPotion(Potion potion)
    {
        SmallPotions.Add(potion);
    }

    public void AddLargePotion(Potion potion)
    {
        LargePotions.Add(potion);
    }

    public void RemoveLargePotion()
    {
        LargePotions.RemoveAt(0);
    }

    public void RemoveSmallPotion()
    {
        SmallPotions.RemoveAt(0);
    }
}
