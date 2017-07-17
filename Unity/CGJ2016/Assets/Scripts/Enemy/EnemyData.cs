public class EnemyData
{
    public string PrefabPath = null;
    public int Lives = 0;
    public int Damage = 0;
    public int Points = 0;
    public int Souls = 0;
    public int Speed = 0;

    public EnemyData(string prefabPath, int lives, int damage, int points, int souls, int speed)
    {
        this.PrefabPath = prefabPath;
        this.Lives = lives;
        this.Damage = damage;
        this.Points = points;
        this.Souls = souls;
        this.Speed = speed;
    }
}