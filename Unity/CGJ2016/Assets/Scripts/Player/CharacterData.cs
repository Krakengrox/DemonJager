
public class CharacterData {

    public string PrefabPath = null;
    public string ProjectileResource = null;
    public string Name = null;
    public string CartPath = null;
    public int SoulstCost = 0;
    public bool Unlocked = false;

    public CharacterData(string prefabPath, string projectileResource, string name, string cartPath, int soulstCost, bool unlocked)
    {
        this.PrefabPath = prefabPath;
        this.ProjectileResource = projectileResource;
        this.Name = name;
        this.CartPath = cartPath;
        this.SoulstCost = soulstCost;
        this.Unlocked = unlocked;
    }

}
