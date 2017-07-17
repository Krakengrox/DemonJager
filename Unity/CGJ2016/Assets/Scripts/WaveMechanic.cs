using UnityEngine;
using System.Collections;

public class SpawnManager
{
    EnemyManager enemyManager = null;
    Player player = null;
    Timers.Timer timer = null;
    float spawnTime;
    float initSacrificeCountLimit;
    float spawnTimeTemp;
    public SpawnManager(EnemyManager enemyManager, Player player)
    {
        this.enemyManager = enemyManager;
        this.player = player;
        //this.player.ritualPlayer.ritualHud.ritualComplete += Init;
        ControllSpawnEnemyInTime();
    }

    public void Init()
    {
        SpawnWave();
    }

    void SpawnWave()
    {
        for (int i = 0; i < GameElementConstants.BonusWave; i++)
        {
            this.enemyManager.InstantiateEnemyRandom();
        }
        DestroyWave();
    }

    public void DestroyWave()
    {
        do
        {
            player.Attack(true);
        } while (enemyManager.Enemies.Count >= 2);

    }

    void ControllSpawnEnemyInTime()
    {
        timer = Timers.TimerFactory.CreateTimer(Timers.TimerType.Seconds, 1);
        timer.ElapsedEvent += EnemyRandomSpawn;
        InitControlSpawnTime();
        timer.Start(this.spawnTime);
    }

    void EnemyRandomSpawn()
    {
        this.enemyManager.InstantiateEnemyRandom();
        timer.Start(this.spawnTime);
        if (this.player.sacrificeCounts.GetSacrificeCount() > GameElementConstants.initSacrificeCountLimit)
        {
            this.initSacrificeCountLimit *= GameElementConstants.multiplierSacrificeCountLimit;
            this.spawnTimeTemp -= GameElementConstants.reduccionSpawnTime;
            if (spawnTimeTemp > 0)
            {
                this.spawnTime = spawnTimeTemp;
            }
        }
    }

    void InitControlSpawnTime()
    {
        this.spawnTime = GameElementConstants.initSpawnTime;
        this.spawnTimeTemp = GameElementConstants.initSpawnTime;
        this.initSacrificeCountLimit = GameElementConstants.initSacrificeCountLimit;
    }

}
