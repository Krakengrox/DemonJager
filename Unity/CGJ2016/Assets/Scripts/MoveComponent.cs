using UnityEngine;
using System.Collections;
using System;

public class MoveComponent : MonoBehaviour
{
    #region Variables
    GamePlayTime gamePlay = null;
    public GameObject target = null;
    //public GameElementConstans.MoveState moveState;
    public Action TargetReachedEvent;
    public bool selfDestroy = false;
    public int speed = 0;
    #endregion

    void Awake()
    {
        this.gamePlay = GamePlayTime.Instance;
    }

    public void Init(GameObject target, int speed)
    {

        this.target = target;
        //this.moveState = moveState;
        this.speed = speed;
    }

    void Update()
    {
        if (this.gamePlay.IsPaused) return;

        this.transform.position += Time.deltaTime * this.speed * this.transform.forward.normalized;

        this.transform.LookAt(target.transform.position);
        if ((this.transform.position - target.transform.position).sqrMagnitude < 0.5f)
        {
            TargetReachedEvent.Trigger();

            if (this.selfDestroy)
            {
                UnityEngine.Object.Destroy(this.gameObject);
            }
        }
    }
}
