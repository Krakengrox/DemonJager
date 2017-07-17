using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource[] enemySources;
    public AudioSource enemySpawn;
    public AudioSource neblina;
    public AudioSource[] playerHitted;
    public AudioSource projectile;

    public AudioSource bg;

    protected override void Awake()
    {

        this.isPersistent = false;
        base.Awake();


        Init();


    }

    public void Init()
    {
        EnemyManager.Instance.EnemySpawnedEvent += (Enemy e) =>
        {
            PlayEnemySpawn();
            e.DiesEvent += () => PlayRandomEnemyDead();
        };

        PlayNeblina();
        PlayBg();
    }

    public bool algo = false;


    public void ProjectileSound()
    {
        this.projectile.Play();
    }

    public void PlayerHitted()
    {
        this.playerHitted[UnityEngine.Random.Range(0, this.playerHitted.Length)].Play();
    }

    void Update()
    {
        if (algo)
        {
            algo = false;
            PlayRandomEnemyDead();
        }
    }

    void PlayBg()
    {
        bg.loop = true;
        bg.Play();
    }

    void PlayNeblina()
    {
        neblina.loop = true;
        neblina.Play();
    }

    public void PlayEnemySpawn()
    {
        enemySpawn.Play();
    }

    public void PlayRandomEnemyDead()
    {
        this.enemySources[UnityEngine.Random.Range(0, this.enemySources.Length)].Play();
    }

}