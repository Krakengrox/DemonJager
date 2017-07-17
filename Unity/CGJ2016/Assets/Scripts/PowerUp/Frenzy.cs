using UnityEngine;
using System.Collections;
using System;

public class Frenzy : IPowerUp
{
    EnemyManager enemyManager = null;
    RitualHud ritualHud = null;
    SelectorMatch selectorMatch = null;
    bool isActive = false;
    public PowerUpType type { get { return PowerUpType.Frenzy; } }

    public string icon { get { return "PowerUp/Frenzy/icon"; } }

    public Frenzy(RitualHud ritualHud)
    {
        this.ritualHud = ritualHud;
        this.enemyManager = EnemyManager.Instance;

        this.ritualHud.inactivePowerUp += InactivePowerUp;
    }

    public void LaunchPowerUp()
    {
        this.selectorMatch = Initializer.Instance.match;
        this.ritualHud.activePowerUp = true;
        this.selectorMatch.user.Pause(true);
        this.selectorMatch.MatchedEvent += RotateSelectors;
        RotateSelectors();

        this.ritualHud.ReduceRitualAmount();
        this.ritualHud.activePowerUp = true;

        this.isActive = true;
    }

    void RotateSelectors()
    {
        RotateToMiddleAngle(this.selectorMatch.user.Target, this.selectorMatch.maxSelectorAngle, this.selectorMatch.minSelectorAngle);
        RotateToMiddleAngle(this.selectorMatch.EnemyTansform, this.selectorMatch.maxSelectorAngle, this.selectorMatch.minSelectorAngle);
    }

    static void RotateToMiddleAngle(Transform target, float upClamp, float downClamp)
    {
        float middleAngle = 0.0f;

        middleAngle = (upClamp + downClamp) / 2;

        target.localEulerAngles = new Vector3(target.localEulerAngles.x, target.localEulerAngles.y, middleAngle);
    }

    public void InactivePowerUp()
    {
        if (this.isActive)
        {
            this.ritualHud.activePowerUp = false;
            this.selectorMatch.user.Pause(false);
            this.selectorMatch.MatchedEvent -= RotateSelectors;
        }
    }
}