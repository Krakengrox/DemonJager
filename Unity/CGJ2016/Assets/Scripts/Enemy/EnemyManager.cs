using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : Singleton<EnemyManager>
{
    #region Variables
    Player player = null;
    List<GameObject> spanwList;
    public SacrificeCounts sacrificeCounts = null;
    public System.Action<Enemy> EnemySpawnedEvent;


    public List<Enemy> Enemies = null;
    #endregion

    protected override void Awake()
    {
        this.isPersistent = false;
        base.Awake();
    }

    public Enemy GetTarget()
    {
        Enemy temp = null;

        float distanceSqr = 0.0f;
        Vector3 playerPos = this.player.playerGameObject.transform.position;
        Vector3 enemyPos = Vector3.zero;

        float minorDistance = float.MaxValue;

        if (this.Enemies.Count > 0)
        {
            for (int i = this.Enemies.Count - 1; i >= 0; i--)
            {
                enemyPos = this.Enemies[i].view.transform.position;
                distanceSqr = (enemyPos - playerPos).sqrMagnitude;

                //criterio de aceptacion para el enemigo mas cercano
                if (distanceSqr < minorDistance)
                {
                    minorDistance = distanceSqr;
                    temp = this.Enemies[i];
                }
            }

        }
        return temp;
    }

    public void Init(Player player, SacrificeCounts sacrificeCounts)
    {
        this.player = player;
        spanwList = new List<GameObject>();
        FindSpawn();
        this.sacrificeCounts = sacrificeCounts;

        this.Enemies = new List<Enemy>();

        this.sacrificeCounts.spawnBoss += SpawnBoss;
    }

    public void InstantiateEnemyRandom()
    {
        if (GamePlayTime.Instance.IsPaused) return;
        if (GameElementConstants.Boss) return;

        //inicializar vergas
        GameElementConstants.EnemyType type = GameElementConstants.EnemyType.RED;
        int length = 0;
        //cuantos elementos hay en el enum?
        length = System.Enum.GetValues(typeof(GameElementConstants.EnemyType)).Length;
        //elige uno
        type = (GameElementConstants.EnemyType)Random.Range(0, length);
        //instantiate dat shit nigga.
        InstantiateEnemy(type);
    }

    public void InstantiateEnemy(GameElementConstants.EnemyType enemyType)
    {
        Enemy enemy = null;

        switch (enemyType)
        {
            case GameElementConstants.EnemyType.YELLOW:
                //enemy = new Enemy(GameElementConstans.MoveState.FAST, this.player, GameElementConstans.enemyYellowPath, enemyType, this);
                enemy = new Enemy(GameElementConstants.Enemies.YellowDemon, this.player, this);
                break;
            case GameElementConstants.EnemyType.RED:
                //enemy = new Enemy(GameElementConstans.MoveState.MEDIUN, this.player, GameElementConstans.enemyRedPath, enemyType, this);
                enemy = new Enemy(GameElementConstants.Enemies.RedDemon, this.player, this);
                break;
            case GameElementConstants.EnemyType.GREEN:
                //enemy = new Enemy(GameElementConstans.MoveState.SLOW, this.player, GameElementConstans.enemyGreenPath, enemyType, this);
                enemy = new Enemy(GameElementConstants.Enemies.GreenDemon, this.player, this);
                break;

            default:
                return;
        }

        EnemyInit(enemy);
    }

    public void EnemyInit(Enemy enemy)
    {
        GameObject mp = RandomSpawn();

        if (mp.name.Contains("4") || mp.name.Contains("5") || mp.name.Contains("6"))
        {
            enemy.Init(true);

        }
        else
        {
            enemy.Init();
        }
        enemy.SpawnPosition(mp);
        this.Enemies.Add(enemy);
        this.EnemySpawnedEvent.Trigger(enemy);
    }

    public void FindSpawn()
    {
        for (int i = 1; i <= GameElementConstants.spawnCount; i++)
        {
            GameObject spawn = GameObject.Find("Spawn" + i);
            spanwList.Add(spawn);
            spawn.SetActive(false);
        }
    }

    public GameObject RandomSpawn()
    {
        int minRandom = 0;
        int maxRandom = GameElementConstants.spawnCount;
        return spanwList[Random.Range(minRandom, maxRandom)];
    }

    public void SpawnBoss()
    {
        Enemy boss = null;
        //boss = new Enemy(GameElementConstants.MoveState.VERYSLOW, this.player, GameElementConstants.enemy4Path, GameElementConstants.EnemyType.RED, this);
        //boss.lifeCount = GameElementConstants.bossLife;
        //boss.enemyHitDamage = GameElementConstants.ritualBossDamage;
        //boss.ritualGain = GameElementConstants.ritualGainEnemyBoss;

        boss = new Enemy(GameElementConstants.Enemies.BlackDemon, this.player, this);

        EnemyInit(boss);
    }
}
