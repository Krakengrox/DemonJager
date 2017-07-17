using UnityEngine;
using System.Collections;
using System;

public class DoublePoints : IPowerUp
{
    EnemyManager enemyManager = null;
    RitualHud ritualHud = null;
    Player player = null;
    public string icon { get { return "PowerUp/DoublePoints/icon"; } }
    public PowerUpType type { get { return PowerUpType.DoublePoints; } }

    public DoublePoints(RitualHud ritualHud)
    {
        this.ritualHud = ritualHud;
        enemyManager = EnemyManager.Instance;
        this.player = PlayerManager.Instance.player;
        this.ritualHud.inactivePowerUp += InactivePowerUp;
    }

    public void LaunchPowerUp()
    {
        GameElementConstants.soulMultiplier = 2;
        this.ritualHud.ReduceRitualAmount();
        this.ritualHud.activePowerUp = true;
    }

    public void InactivePowerUp()
    {
        GameElementConstants.soulMultiplier = 1;
        this.ritualHud.activePowerUp = false;
    }
}
