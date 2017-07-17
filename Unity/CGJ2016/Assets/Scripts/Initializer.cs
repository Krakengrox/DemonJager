using UnityEngine;
using System.Collections;
using System;
using UI.Behaviours.GamePlay;

public class Initializer : Singleton<Initializer>
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
    public GamePlayManager UI = null;
    public bool delectPlayerPref = false;
    public User userData = null;


    #endregion


    protected override void Awake()
    {
        this.isPersistent = false;
        base.Awake();
    }

    public void Initialize()
    {
        DataLoad.InitData();
        this.gamePlay = GamePlayTime.Instance;
        this.gamePlay.Initialize();

        PlayerManager.Instance.InstantiatePlayer();
        sacrificeCounts = new SacrificeCounts();

        this.player = PlayerManager.Instance.player;
        this.player.sacrificeCounts = this.sacrificeCounts;

        this.player.LiveChangesEvent += (int arg) => { if (arg <= 0) GameOver(); };


        enemyManager = EnemyManager.Instance;

        enemyManager.Init(this.player, this.sacrificeCounts);


        GameElementConstants.gameState = GameElementConstants.GameState.Start;


        this.UI = GamePlayManager.Instance;

        PlayerManager.Instance.player.LiveChangesEvent += this.UI.gamePlay.HUDScreen.playerLivesEventHandler;

        this.UI.Init();
        this.UI.gamePlay.WelcomeScreen.Init(this.UI.gamePlay.TapScreen.TapEvent);
        this.UI.gamePlay.WelcomeScreen.TapEvent += () =>
            {
                GameElementConstants.gameState = GameElementConstants.GameState.Playing;
                EnemyManager.Instance.InstantiateEnemyRandom();
                this.match.Init();
                this.match.UserInit();
                this.gamePlay.PausedEvent += this.match.user.Pause;
            };

        this.match = SelectorMatch.Instance;

        this.match.MatchedEvent += MatchedEventConnections();

        waveMechanic = new SpawnManager(this.enemyManager, this.player);
        this.gamePlay.SetPause(false);


        InitializeCombo();
    }

    Combo combo = null;
    void InitializeCombo()
    {

        this.combo = new Combo();
        this.match.MatchedEvent += this.combo.matchEventHandler;
        this.match.MissEvent += this.combo.missEventHandler;
        this.combo.ComboEvent += this.UI.gamePlay.HUDScreen.ComboNotification.ComboEventHandler;

    }
    void GameOver()
    {

        this.UI.gamePlay.GameOverScreen.gameObject.SetActive(true);
        this.gamePlay.SetPause(true);
        this.player.sacrificeCounts.AddSacrificeGameOver();
        this.UI.gamePlay.GameOverScreen.ReviveVerification();

        CheckHighScore();
    }


    void CheckHighScore()
    {
        int thisRoundScore = this.player.sacrificeCounts.sacrificeCount;
        int HighScore = this.player.userData.HighScore;
        this.player.userData.Souls += thisRoundScore;

        if (thisRoundScore >= HighScore)
        {
            HighScore = thisRoundScore;
            this.player.userData.HighScore = thisRoundScore;

            Social.ReportScore(HighScore, "CgkIptKdiJkJEAIQBw", (bool success) =>
            {
                // handle success or failure
            });

        }

        DataService.instance.UpdateTable(this.player.userData);
        this.UI.gamePlay.GameOverScreen.HighScore.text = HighScore.ToString();
    }


    Action MatchedEventConnections()
    {
        Action actions = null;
        actions += PlayerManager.Instance.player.Attack;
        actions += () => { if (EnemyManager.Instance.Enemies.Count <= 1) EnemyManager.Instance.InstantiateEnemyRandom(); };
        return actions;
    }

    void Update()
    {
        if (spawnBlue)
        {

            enemyManager.InstantiateEnemy(GameElementConstants.EnemyType.YELLOW);
            spawnBlue = false;
        }


        if (spawnRed)
        {
            enemyManager.InstantiateEnemy(GameElementConstants.EnemyType.RED);
            spawnRed = false;
        }

        if (spawnGreen)
        {
            enemyManager.InstantiateEnemy(GameElementConstants.EnemyType.GREEN);
            spawnGreen = false;
        }

        if (wave)
        {
            this.waveMechanic.Init();
            wave = false;
        }
        wave = false;

        if (destroyWave)
        {
            this.waveMechanic.DestroyWave();
            destroyWave = false;
        }

        if (delectPlayerPref)
        {
            PlayerPrefs.DeleteAll();
            delectPlayerPref = false;
        }

    }

}
