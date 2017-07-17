using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SacrificeCounts
{
    Text textCountGamePlay = null;
    Text textCountGameOver = null;
    public int sacrificeCount = 0;
    int enemyDeadCount = 0;
    public Action spawnBoss;
    UI.Behaviours.GamePlay.GamePlayManager uiManager = null;

    public SacrificeCounts()
    {
        Init();
    }

    void Init()
    {
        this.uiManager = UI.Behaviours.GamePlay.GamePlayManager.Instance;
        this.textCountGameOver = this.uiManager.gamePlay.GameOverScreen.SacrificeCount;

        this.textCountGamePlay = this.uiManager.gamePlay.HUDScreen.Score;
        this.textCountGamePlay.text = "0";
    }

    public void AddSacrifice(int amount)
    {
        sacrificeCount += amount;
        this.textCountGamePlay.text = sacrificeCount.ToString();
        this.uiManager.gamePlay.PauseScreen.Score.text = sacrificeCount.ToString();

    }

    public void AddSacrificeGameOver()
    {
        this.textCountGameOver.text = sacrificeCount.ToString();
    }
    public void AddDeadCount(int amount)
    {

        this.enemyDeadCount += amount;
        if (this.enemyDeadCount >= GameElementConstants.invocationBoss)
        {
            this.enemyDeadCount = 0;
            spawnBoss();
        }

    }

    public int GetSacrificeCount()
    {
        return this.sacrificeCount;
    }
}
