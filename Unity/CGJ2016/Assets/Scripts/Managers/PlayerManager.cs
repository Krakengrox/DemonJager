using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public Player player = null;

    protected override void Awake()
    {
        this.isPersistent = true;
        base.Awake();
    }

    public void InstantiatePlayer()
    {

        this.player = new Player(DataService.instance.GetUserData());
        this.player.Init();
        this.player.HitedEvent += AudioManager.Instance.PlayerHitted;

    }
}
