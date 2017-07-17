using UnityEngine;

public class TimerManager : Singleton<TimerManager>
{
    protected override void Awake()
    {
        this.isPersistent = false;
        base.Awake();
    }
}
