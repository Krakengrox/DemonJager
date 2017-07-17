using UnityEngine;
using System.Collections;

public class ScenesManager : Singleton<ScenesManager>
{
    #region Variables
    CanvasUIManager ui = null;
    #endregion

    protected override void Awake()
    {
        this.isPersistent = true;
        base.Awake();
    }

    public void ChangeScene(string name)
    {
        Application.LoadLevel(name);
    }

    // This function is called after a new level was loaded
    public void OnLevelWasLoaded(int level)
    {
        string levelName = Application.loadedLevelName;

        switch (levelName)
        {
            case "main":
                //ui = CanvasUIManager.Instance;
                break;
            default:
                break;
        }
    }
}
