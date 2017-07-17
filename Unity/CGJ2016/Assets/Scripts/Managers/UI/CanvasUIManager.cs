using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIManager : Singleton<CanvasUIManager>
{

    #region Variables
    GameObject canvasMain = null;
    GameObject canvasHUD = null;

    GameObject canvasGameOver = null;
    GameObject GameOver = null;
    GameObject Main = null;
    GameObject GUI = null;
    GameObject pauseUI = null;
    Button pauseButton = null;
    bool pause = true;
    GamePlayTime gamePlay = null;

    #endregion
    protected override void Awake()
    {
        base.Awake();

        Init();
    }

    void Init()
    {
        this.gamePlay = GamePlayTime.Instance;
        GetElemets();

        StartEventHandler();
    }

    void GetElemets()
    {
        canvasMain = GameObject.FindGameObjectWithTag("Canvas/Main");
        canvasGameOver = GameObject.FindGameObjectWithTag("Canvas/GameOver");
        canvasHUD = GameObject.FindGameObjectWithTag("Canvas/HUD");

        GameOver = canvasGameOver.transform.FindChild("GameOver").gameObject;
        Main = canvasMain.transform.FindChild("Main").gameObject;
        GUI = canvasHUD.transform.FindChild("GUI").gameObject;
        pauseUI = GUI.transform.FindChild("Pause").gameObject;
        pauseButton = pauseUI.transform.FindChild("Btn_Pause").gameObject.GetComponent<Button>();
        pauseButton.onClick.AddListener(PauseManager);

        Reset();
    }

    public void PlayEventHandler()
    {
        turnOffMain();
        GameElementConstants.gameState = GameElementConstants.GameState.Playing;
        EnemyManager.Instance.InstantiateEnemyRandom();
    }

    public void GameStateEventHandler()
    {
        switch (GameElementConstants.gameState)
        {
            case GameElementConstants.GameState.None:
                break;
            case GameElementConstants.GameState.Start:
                PlayEventHandler();
                break;
            case GameElementConstants.GameState.Playing:
                break;
            case GameElementConstants.GameState.Paused:
                break;
            case GameElementConstants.GameState.GameOver:
                RestartEventHandler();
                break;
            default:
                break;
        }
    }

    public void GameOverEventHandler()
    {
        if (GameElementConstants.gameState == GameElementConstants.GameState.Playing)
        {
            GameElementConstants.gameState = GameElementConstants.GameState.GameOver;

            turnOnGameOver();
        }
    }

    public void RestartEventHandler()
    {
        Application.LoadLevel("Gameplay");
    }

    public void Reset()
    {
        //this.canvasUI = null;
        //this.UI.SetActive(false);
        this.GameOver.SetActive(false);
        this.Main.SetActive(false);
    }

    public void StartEventHandler()
    {
        //this.UI.SetActive(true);
        this.GameOver.SetActive(false);
        this.Main.SetActive(true);
    }


    void turnOffMain()
    {
        Reset();
    }
    void turnOnGameOver()
    {
        //this.UI.SetActive(true);
        this.GameOver.SetActive(true);
    }

    void PauseManager()
    {
        this.gamePlay.SetPause(!this.gamePlay.IsPaused);
        //GameElementConstans.pause = pause;
        //pause = !pause;
    }
}
