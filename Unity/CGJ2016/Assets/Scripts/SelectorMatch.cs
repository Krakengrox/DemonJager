using UnityEngine;
using System;
using Timers;

public class SelectorMatch : Singleton<SelectorMatch>
{
    #region Variables
    public Transform UserTransform = null;
    public Transform EnemyTansform = null;

    public Selector user = null;
    public Selector enemy = null;

    public static string UserSelectorTag = "AttackMask/User";
    public const string EnemySelectorTag = "AttackMask/Enemy";

    public Animator UserTransformAnimator = null;

    public float selectorStep = 1.0f;
    public float selectorStepMultiplier = 5.0f;
    public float max = GameElementConstants.maxSpeedBar;
    public float min = GameElementConstants.minSpeedBar;

    public float enemyCount = 0;

    UI.Behaviours.GamePlay.GamePlayManager uiManager = null;


    EnemySelector enemyS = null;

    #region Angles
    public float minSelectorAngle = 120.0f;
    public float maxSelectorAngle = 240.0f;
    #endregion

    int SelectorDivisions = 7;

    ZigZag zigZag = null;


    #region Events
    public Action MatchedEvent;
    public Action TapEvent;
    public Action MissEvent;
    #endregion
    #endregion

    #region Methods

    protected override void Awake()
    {
        this.isPersistent = false;
        base.Awake();
    }

    public void Init()
    {
        this.UserTransform = GameObject.FindGameObjectWithTag(UserSelectorTag).transform;
        this.EnemyTansform = GameObject.FindGameObjectWithTag(EnemySelectorTag).transform;

        this.UserTransformAnimator = UserTransform.GetComponent<Animator>();

        this.user = new Selector(
            target: this.UserTransform,
            step: GameElementConstants.minSpeedBar,
            downClamp: this.minSelectorAngle,
            upClamp: this.maxSelectorAngle);

        this.uiManager = UI.Behaviours.GamePlay.GamePlayManager.Instance;

        this.uiManager.gamePlay.TapScreen.TapEvent += CheckMatch;

        this.zigZag = new ZigZag(
            lowerClamp: this.minSelectorAngle,
            upperClamp: this.maxSelectorAngle,
            divisions: this.SelectorDivisions);

        this.enemyS = new EnemySelector(GameObject.FindGameObjectWithTag(EnemySelectorTag));
        this.enemyS.Init();
    }

    void SpeedUp()
    {
        this.user.Step += GameElementConstants.speedBarChangeCount;

        if (this.user.Step > max) this.user.Step = max;

    }

    void SpeedDowm()
    {
        this.user.Step -= GameElementConstants.speedBarChangeCount;

        if (this.user.Step < min) this.user.Step = min;
    }

    bool match()
    {
        //Debug.Log(this.enemyS.isMatcheable());
        //return this.user.isOnTrigger;
        return this.enemyS.isMatcheable();
    }

    void newEnemySelectorAngle()
    {

        int currentDivision = 0;
        int nextDivision = 0;
        float lowerClamp = 0.0f;
        float uppperClamp = 0.0f;
        float newEnemyAngle = 0.0f;

        currentDivision = this.zigZag.CalculateDivision(this.EnemyTansform.localEulerAngles.z);

        nextDivision = calculateNextDivision(currentDivision);

        this.zigZag.GetDivisionLimits(nextDivision, out lowerClamp, out uppperClamp);

        newEnemyAngle = UnityEngine.Random.Range(lowerClamp, uppperClamp);

        this.EnemyTansform.localEulerAngles = new Vector3
            (
                this.EnemyTansform.localEulerAngles.x,
                this.EnemyTansform.localEulerAngles.y,
                newEnemyAngle
            );
    }

    int calculateNextDivision(int currentDivision)
    {
        return this.zigZag.NextDivision(currentDivision, this.user.direction > 0 ? true : false, 2);
    }

    void Update()
    {
        CheckInputs();
    }


    void CheckInputs()
    {

        tapUp(this.TapEvent);
        if (GameElementConstants.gameState == GameElementConstants.GameState.Playing)
        {
            keyDown(KeyCode.G, MatchEventHandler);
            keyDown(KeyCode.M, () => { UserInit(); });
            keyDown(KeyCode.Space, CheckMatch);
        }
    }

    void CheckMatch()
    {
        if (GameElementConstants.gameState == GameElementConstants.GameState.Playing)
        {
            if (match())
            {
                MatchEventHandler();
                UserTransformAnimator.SetTrigger("God");
                SpeedDowm();
            }
            else
            {
                EnemyManager.Instance.InstantiateEnemyRandom();
                UserTransformAnimator.SetTrigger("Bad");
                SpeedUp();
                this.MissEvent.Trigger();
            }
        }
    }

    void MatchEventHandler()
    {

        newEnemySelectorAngle();

        this.MatchedEvent.Trigger();
    }

    public void UserInit()
    {
        if (!this.user.timer.IsRunning)
        {
            this.user.Init(0.01f);
        }

    }

    public static void keyDown(KeyCode key, Action action)
    {
        if (Input.GetKeyDown(key))
        {
            action.Trigger();
        }
    }

    public static void tapUp(Action action)
    {

        if (Input.GetMouseButtonDown(0))
        {
            //UnityEditor.EditorApplication.isPaused = true;
            //action.Trigger();
        }

        if (Input.touchCount>0)
        {
            action.Trigger();

        }
    }
    #endregion
}
