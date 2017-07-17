using UnityEngine;
using System.Collections;
using System;
using Timers;
using UnityEngine.UI;

public class Enemy
{

    #region Variables
    public GameObject view = null;
    Player player = null;
    MoveComponent move = null;
    Timer deathTimer = null;
    public int lifeCount = 0;
    const string deathTrigger = "death";
    const string enemyHit = "hit";
    Animator animator = null;

    public EnemyState state = EnemyState.None;

    public Action DiesEvent;

    EnemyManager enemyManager = null;

    private int healthPreview = 0;

    public int HealthPreview
    {
        get { return healthPreview; }
    }

    private int health = 0;

    public int Health
    {
        get { return health; }
    }


    EnemyData data = null;

    TextMesh text = null;
    #endregion

    public Enemy(EnemyData data, Player player, EnemyManager enemyManager)
    {
        this.data = data;
        this.player = player;
        this.enemyManager = enemyManager;
        this.healthPreview = this.data.Lives;
        this.health = this.data.Lives;
        InternalInitializationOfVariables();
    }

    void InternalInitializationOfVariables()
    {

        this.deathTimer = TimerFactory.CreateTimer(TimerType.Seconds);
        this.deathTimer.ElapsedEvent += Destroy;

    }

    public void Init(bool rotado = false)
    {
        InstanceEnemy(rotado);
        AddMoveComponent();

        this.state = EnemyState.Alive;
    }

    void InstanceEnemy(bool rotado)
    {
        this.view = GameObject.Instantiate(Resources.Load<GameObject>(this.data.PrefabPath));
        this.view.transform.localEulerAngles = Vector3.zero;
        this.animator = this.view.GetComponent<Animator>();

        if (rotado) this.view.transform.Find("Run").localEulerAngles = new Vector3(0, 180, 0);


        this.text = this.view.GetComponentsInChildren<TextMesh>(true)[0];
    }

    void AddMoveComponent()
    {
        move = this.view.AddComponent<MoveComponent>();
        move.target = this.player.playerGameObject;
        move.speed = this.data.Speed;
        move.TargetReachedEvent += EnemyHit;
    }

    void EnemyHit()
    {
        if (this.state == EnemyState.Alive)
        {
            RemoveFromTargetting();
            this.player.HitMe(this.data.Damage);

            Kill(false);
        }
    }

    public void DamagePreview(int amount)
    {
        this.healthPreview -= amount;

        if (this.healthPreview <= 0)
        {
            DeathPreview();
        }
    }

    public void DeathPreview()
    {
        RemoveFromTargetting();
    }

    public void ApplyDamage(int amount)
    {
        this.health -= amount;

        if (this.health <= 0)
        {
            PlayerHit(false);
        }
        else
        {
            this.animator.SetTrigger(enemyHit);
        }
    }

    bool PlayerHit(bool wave)
    {
        if (state == EnemyState.Alive)
        {
            this.text.text = (this.data.Points * GameElementConstants.soulMultiplier).ToString();
            Kill(true);

            this.player.sacrificeCounts.AddSacrifice(this.data.Points * GameElementConstants.soulMultiplier);
            if (!wave)
            {
                this.player.sacrificeCounts.AddDeadCount(1);
                this.player.UpRitual(this.data.Souls);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Kill(bool killed)
    {
        this.state = EnemyState.Dead;
        this.text.gameObject.SetActive(killed);
        this.animator.SetTrigger(deathTrigger);
        this.move.enabled = false;
        this.DiesEvent.Trigger();
        this.deathTimer.Start(5.0f);
    }

    public void SpawnPosition(GameObject position)
    {
        this.view.transform.position = position.transform.position;
        position.SetActive(true);
    }

    public bool ValidatedLive()
    {
        if (state == EnemyState.Dead)
            return false;
        lifeCount -= 1;
        return (lifeCount <= 0);
    }

    public void RemoveFromTargetting()
    {
        this.enemyManager.Enemies.Remove(this);
    }

    void Destroy()
    {
        UnityEngine.Object.Destroy(this.view);

    }

}
