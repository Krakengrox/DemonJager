using UnityEngine;
using System.Collections;
using System;

public class ExtraLive : IPowerUp
{
    RitualHud ritualHud = null;
    Player player = null;
    public string icon { get { return "PowerUp/ExtraLive/icon"; } }
    public PowerUpType type { get { return PowerUpType.ExtraLive; } }

    public ExtraLive(RitualHud ritualHud)
    {
        this.ritualHud = ritualHud;
        this.player = PlayerManager.Instance.player;
    }

    public void LaunchPowerUp()
    {
        this.player.Lives++;
        ritualHud.ResetRitualAmount();
    }

}
