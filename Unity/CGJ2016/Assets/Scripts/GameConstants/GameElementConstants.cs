using UnityEngine;
using System.Collections;

public static partial class GameElementConstants
{
    #region Game
    public enum GameState
    {
        None,
        Start,
        Playing,
        Paused,
        GameOver,
        Boss,
    }

    public static float CameraShake = 0.1f;


    public static bool Boss = false;
    public static GameState gameState = GameState.None;
    //public static bool pause = false;

    public static float minSpeedBar = 80f;
    public static float maxSpeedBar = 90f;
    public static float speedBarChangeCount = 5f;

    // El tiempo de inicio del spawn en segundos
    public static float initSpawnTime = 16;
    // cantidad limite iniciar para subir
    public static int initSacrificeCountLimit = 8;
    // multiplicador de cantidad minima cuando llegue al init osea 5 *2 =10 este es el nuevo init
    public static int multiplierSacrificeCountLimit = 2;
    // cantidad de tiempo a reducir cuando toque los limite
    public static float reduccionSpawnTime = 4;
    // multiplicador de almas
    public static int soulMultiplier = 1;
    #endregion

    #region Player
    public static string playerPath = "Hero";
    public static float timeUpProgresiveBar = 0.15f;
    #endregion

    #region Enemy
    public static int spawnCount = 6;

    public static int bulletVelocity = 18;
    public static int invocationBoss = 100;

    #endregion

    #region Bonus
    public static int BonusWave = 10;

    #endregion

    public enum MoveState
    {

        STOP,
        VERYSLOW,
        SLOW,
        MEDIUN,
        FAST,
        BULLET

    }

    public enum EnemyType
    {
        RED,
        YELLOW,
        GREEN,
    }

}
