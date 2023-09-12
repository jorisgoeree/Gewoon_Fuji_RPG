public class Quest
{
    public int ID;
    public string Name;
    public string Description;
    public bool QuestAccepted = false;

    public Quest(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
    }
}
