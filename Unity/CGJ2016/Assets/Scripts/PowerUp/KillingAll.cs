using UnityEngine;
using System.Collections;
using System;

public class KillingAll : IPowerUp
{
    EnemyManager enemyManager = null;
    RitualHud ritualHud = null;
    Player player = null;
    public PowerUpType type { get { return PowerUpType.KillingAll; } }

    public string icon { get { return "PowerUp/KillingAll/icon"; } }


    public KillingAll(RitualHud ritualHud)
    {
        this.ritualHud = ritualHud;
        enemyManager = EnemyManager.Instance;
        this.player = PlayerManager.Instance.player;
    }

    public void LaunchPowerUp()
    {
        do
        {
            this.player.Attack(true);
        } while (enemyManager.Enemies.Count >= 1);
        ritualHud.ResetRitualAmount();
    }
}
