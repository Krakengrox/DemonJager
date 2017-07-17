using System;
using System.Collections.Generic;
using UnityEngine;


public enum GamePlayMode
{
    None,
    Story,
    Survive,
    CharacterSelect,
}

public class GameManager : Singleton<GameManager>
{

    #region Variables
    public bool isInitialized = false;
    public DataManager dataManager = null;
    public ScenesManager scenesManager = null;
    public GamePlayMode gamePlayMode = GamePlayMode.None;
    public AdsManager adsManager = null;
    public BannerViewManager bannerViewManager = null;
    #endregion

    #region Methods

    protected override void Awake()
    {
        this.isPersistent = true;
        base.Awake();
    }

    public void Initialize()
    {
        //cache singletons
        this.dataManager = DataManager.Instance;
        this.scenesManager = ScenesManager.Instance;
        Debug.Log("init");
        this.adsManager = AdsManager.Instance;
        this.bannerViewManager = new BannerViewManager();
        this.bannerViewManager.InitBanner();
        this.dataManager.initializedEvent += InitializationScenesManagement;
        this.dataManager.Initialize();
        this.dataManager.initializedEvent -= InitializationScenesManagement;

        this.isInitialized = true;
    }

    void InitializationScenesManagement()
    {
        this.scenesManager.ChangeScene("main");
    }

    public void OnLevelWasLoaded(int level)
    {
        switch (this.gamePlayMode)
        {
            case GamePlayMode.Story:
                StoryInitializer.Instance.Initialize();
                break;
            case GamePlayMode.Survive:
                Initializer.Instance.Initialize();
                break;
            default:
                break;
        }
    }

    public void GoToStoryMode()
    {
        this.gamePlayMode = GamePlayMode.Story;
        scenesManager.ChangeScene("Gameplay");

    }

    public void GoToSurviveMode()
    {
        this.bannerViewManager.HideBanner();
        this.gamePlayMode = GamePlayMode.Survive;
        scenesManager.ChangeScene("Gameplay");
    }

    public void GoToHome()
    {
        this.bannerViewManager.ShowBanner();
        this.gamePlayMode = GamePlayMode.None;
        scenesManager.ChangeScene("main");
    }
    #endregion
}
