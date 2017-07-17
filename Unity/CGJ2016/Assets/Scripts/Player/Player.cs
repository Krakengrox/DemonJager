using UnityEngine;
using System.Collections;
using System;

public class Player
{

    #region Variables

    public GameObject playerGameObject = null;

    GameObject projectileResource = null;
    GameObject projectileInstance = null;
    GameObject projectileTarget = null;
    public Ritual ritualPlayer = null;
    Animator animator = null;
    public User userData = null;
    Character characterData = null;
    Transform projectileMP = null;
    public bool iRevive;

    public SacrificeCounts sacrificeCounts = null;

    const string attackTrigger = "Ritual";
    const string projectileMPName = "AttackMP";

    public Action HitedEvent;

    EnemyManager enemyManager = null;


    private int lives;

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            LiveChangesEvent.Trigger(value);
        }
    }

    public Action<int> LiveChangesEvent;

    public int MaxLives = 3;
    #endregion

    public Player(User data)
    {
        //get singleton references.
        this.enemyManager = EnemyManager.Instance;
        this.characterData = new Character();

        this.userData = data;
        this.characterData = DataService.Instance.GetCharactersInUse(this.userData.CharacterEquip);
        //this.playerPath = playerPath;

        this.projectileResource = Resources.Load<GameObject>(characterData.ProjectileResource);

        this.Lives = this.MaxLives;
        iRevive = false;
    }

    #region Methods
    public void Init()
    {
        InstanciatePlayer();
        this.ritualPlayer = new Ritual(this, GameElementConstants.ritualAmount);
    }

    void InstanciatePlayer()
    {
        this.playerGameObject = GameObject.Instantiate(Resources.Load<GameObject>(this.characterData.PrefabPath));

        this.animator = this.playerGameObject.GetComponent<Animator>();

        this.projectileMP = this.playerGameObject.transform.FindChild(projectileMPName);
    }

    public void Attack()
    {
        Attack(false);
    }

    public void Attack(bool wave)
    {
        Enemy enemy = null;

        enemy = GetTarget();

        if (enemy != null)
        {
            this.animator.SetTrigger(attackTrigger);
            enemy.DamagePreview(amount: 1);
            instantiateProjectile(
                enemyTarget: enemy,
                wave: wave,
                damage: 1);
        }
    }

    public void instantiateProjectile(Enemy enemyTarget, bool wave, int damage)
    {

        this.projectileInstance = GameObject.Instantiate<GameObject>(projectileResource);

        this.projectileInstance.transform.position = this.projectileMP.position;

        AudioManager.Instance.ProjectileSound();
        this.projectileTarget = enemyTarget.view;

        addMoveComponent(enemyTarget, wave, damage);


    }

    public void HitMe(float hit)
    {
        //this.ritualPlayer.ritualHud.ReduceRitualAmount(hit);
        CamaraController.Instance.Shake();

        HitedEvent.Trigger();

        this.Lives--;
        //this.LiveChangesEvent.Trigger(this.Lives);
    }

    public void UpRitual(float amount)
    {
        this.ritualPlayer.ritualHud.UpRitualAmount(amount);
    }

    void addMoveComponent(Enemy enemy, bool wave, int damage)
    {
        MoveComponent mc = null;
        mc = this.projectileInstance.AddComponent<MoveComponent>();

        mc.Init(this.projectileTarget, GameElementConstants.bulletVelocity);

        mc.selfDestroy = true;

        mc.TargetReachedEvent += () => enemy.ApplyDamage(amount: damage);

    }

    Enemy GetTarget()
    {
        return this.enemyManager.GetTarget();
    }
    #endregion
}
