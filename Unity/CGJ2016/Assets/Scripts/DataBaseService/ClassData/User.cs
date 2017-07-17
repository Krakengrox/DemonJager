using SQLite4Unity3d;

public class User  {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Name { get; set; }
	public int Souls { get; set; }
	public int HighScore { get; set; }
    public int CharacterEquip { get; set; }

    public override string ToString ()
	{
		return string.Format ("[User: Id={0}, Name={1},  Souls={2}, HighScore={3}, CharacterEquip={4}]", Id, Name, Souls, HighScore, CharacterEquip);
	}
}
