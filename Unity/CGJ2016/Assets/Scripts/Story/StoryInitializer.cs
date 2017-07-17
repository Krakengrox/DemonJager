using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StoryInitializer : Singleton<StoryInitializer>
{

    #region Variables
    public bool spawnBlue = false;
    public bool spawnRed = false;
    public bool spawnGreen = false;
    Player player = null;
    public bool wave;
    public bool destroyWave;
    public SelectorMatch match = null;
    public EnemyManager enemyManager = null;
    public SpawnManager waveMechanic = null;
    public SacrificeCounts sacrificeCounts = null;


    public GamePlayTime gamePlay = null;


    public UI.Behaviours.GamePlay.GamePlayManager UIManager = null;
    public PlayerManager playerManager = null;
    #endregion

    public void Initialize()
    {
        //Get Singletons;
        this.gamePlay = GamePlayTime.Instance;
        this.UIManager = UI.Behaviours.GamePlay.GamePlayManager.Instance;
        this.playerManager = PlayerManager.Instance;

        //instantiate player
        this.playerManager.InstantiatePlayer();
        //initialize UI
        this.UIManager.Init();

        this.UIManager.gamePlay.WelcomeScreen.Init(this.UIManager.gamePlay.TapScreen.TapEvent);
    }

}
