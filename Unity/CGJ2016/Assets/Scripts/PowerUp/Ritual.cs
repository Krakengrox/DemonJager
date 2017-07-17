using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Ritual
{

    public RitualHud ritualHud = null;
    public List<IPowerUp> powerUpList = null;
    public IPowerUp powerUp = null;
    public Action ReductionRitualBar = null;
    Player player = null;

    public Ritual(Player player, float ritualAmount)
    {
        this.player = player;
        this.ritualHud = new RitualHud(ritualAmount);
        Init();
    }

    public void Init()
    {
        this.ritualHud.TriggerRitualEvent += BonusActive;
        this.powerUpList = new List<IPowerUp>();
        InitAllPowerUp();
        FindNewPowerUp();
    }

    public void InitAllPowerUp()
    {

        this.powerUpList.Add(new KillingAll(this.ritualHud));
        this.powerUpList.Add(new DoublePoints(this.ritualHud));
        this.powerUpList.Add(new Frenzy(this.ritualHud));
        this.powerUpList.Add(new ExtraLive(this.ritualHud));

    }

    public void FindNewPowerUp()
    {

        do
        {
            this.powerUp = powerUpList[UnityEngine.Random.Range(0, this.powerUpList.Count)];
        } while (!PowerUpRules(this.powerUp.type));

        ritualHud.powerUpIcon.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(this.powerUp.icon);
    }

    public void BonusActive()
    {
        powerUp.LaunchPowerUp();
        this.ritualHud.SetActiveRitual(false);
        FindNewPowerUp();
    }

    public bool PowerUpRules(PowerUpType type)
    {

        switch (type)
        {
            case PowerUpType.KillingAll:
                return true;
            case PowerUpType.DoublePoints:
                return true;
            case PowerUpType.Frenzy:
                return true;
            case PowerUpType.ExtraLive:
                return (this.player.Lives < this.player.MaxLives);
            default:
                return false;
        }

    }

}

public enum PowerUpType
{
    KillingAll,
    DoublePoints,
    Frenzy,
    ExtraLive,
}