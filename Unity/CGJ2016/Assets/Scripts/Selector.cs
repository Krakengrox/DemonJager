using Timers;
using UnityEngine;
using General.UnityMessages;

public class Selector
{
    #region Variables
    public float DownClamp = 0.0f;
    public float UpClamp = 0.0f;
    public float Step = 0.0f;

    public Transform Target = null;
    public Timer timer = null;

    public float TimerInterval = 0.0f;

    OnTriggerEnterMessage triggerEnter = null;
    OnTriggerExitMessage triggerExit = null;
    public bool isOnTrigger = false;

    public float currentAngle = 0.0f;
    public float direction = 1.0f;
    #endregion

    #region Methods

    public Selector(Transform target, float step = 1.0f, float downClamp = 120.0f, float upClamp = 240.0f)
    {
        this.Target = target;
        this.Step = step;
        this.DownClamp = downClamp;
        this.UpClamp = upClamp;

        this.timer = TimerFactory.CreateTimer(TimerType.EndOfFrame);

        this.timer.ElapsedEvent += MakeStep;
        this.timer.ElapsedEvent += Loop;

        this.triggerEnter = this.Target.gameObject.GetBehaviour<OnTriggerEnterMessage>();
        this.triggerEnter.action += CollisionEventHandler;

        this.triggerExit = this.Target.gameObject.GetBehaviour<OnTriggerExitMessage>();
        this.triggerExit.action += OnTriggerExitEventHandler;
    }

    void OnTriggerExitEventHandler(Collider go)
    {
        this.isOnTrigger = false;
    }

    void CollisionEventHandler(Collider go)
    {
        this.isOnTrigger = true;
    }

    public void Loop()
    {
        this.timer.Start(this.TimerInterval);
    }

    public void Init(float time)
    {
        this.TimerInterval = time;
        this.timer.Start(time);
    }

    public void MakeStep()
    {
        Rotate(calculateStepDirection());
    }

    public float calculateStepDirection()
    {
        float _step = 0.0f;

        float angle = this.Target.localRotation.eulerAngles.z;

        //if the angle is bigger than the claps, change direction
        if (angle > this.UpClamp)
        {
            direction = -1.0f;
        }
        else if (angle < this.DownClamp)
        {
            direction = 1.0f;
        }

        _step = this.Step * direction * Time.deltaTime;

        return _step;
    }

    public void Rotate(float angle)
    {
        this.currentAngle = this.Target.localRotation.eulerAngles.z + angle;

        this.Target.localEulerAngles = new Vector3(
                this.Target.localRotation.eulerAngles.x,
                this.Target.localRotation.eulerAngles.y,
                this.Target.localRotation.eulerAngles.z + angle);
    }

    public void Pause(bool value)
    {
        this.timer.SetPause(value);
    }
    #endregion
}
