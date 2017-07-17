using SQLite4Unity3d;

public class Character
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int SoulsCost { get; set; }
    public string CartPath { get; set; }
    public string PrefabPath { get; set; }
    public string ProjectileResource { get; set; }
    public string Unlocked { get; set; }


    public override string ToString()
    {
        return string.Format("[User: Id={0}, Name={1},  SoulsCost={2}, CartPath={3}, PrefabPath={4}, ProjectileResource={5}, Unlocked={6}]", Id, Name, SoulsCost, CartPath, PrefabPath, ProjectileResource, Unlocked);
    }
}
