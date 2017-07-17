using SQLite4Unity3d;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class DataService : Singleton<DataService>
{
    public bool isInitialized = false;
    private SQLiteConnection connection = null;
    private IEnumerable<User> userData = null;
    private IEnumerable<Character> characterData = null;


    protected override void Awake()
    {
        this.isPersistent = false;
        base.Awake();
    }

    public void Initialize()
    {

#if UNITY_EDITOR
        string dbPath = "Assets/StreamingAssets/GameDB.db";
#else

#if UNITY_ANDROID
        // check if file exists in Application.persistentDataPath
        //var filepath = string.Format("{0}/{1}", Application.persistentDataPath, "GameDB.db");

        string filepath = Application.persistentDataPath + "/" + "GameDB.db";

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "GameDB.db");  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);

#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif

        this.connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        Debug.Log("Final PATH: " + dbPath);

        LoadData();

        this.isInitialized = true;

    }

    public void LoadData()
    {
        this.userData = this.connection.Table<User>();
        this.characterData = this.connection.Table<Character>();
    }

    public IEnumerable<Character> GetCharacters()
    {
        return this.characterData;
    }

    public Character GetCharactersInUse(int id)
    {
        return this.connection.Table<Character>().Where(x => x.Id == id).FirstOrDefault();
    }

    public User GetUserData()
    {
        return this.connection.Table<User>().FirstOrDefault();
    }

    public void UpdateTable(object obj)
    {
        connection.Update(obj);
    }

    public void Insert(object obj)
    {
        connection.Insert(obj);
    }
}
