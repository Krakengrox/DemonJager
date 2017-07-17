using System.Collections.Generic;
using UnityEngine;
using Timers;

public class CamaraController : Singleton<CamaraController>
{

    Camera mainCamera = null;
    Timer timer = null;

    protected override void Awake()
    {
        this.isPersistent = false;
        base.Awake();

        mainCamera = Camera.main;

        this.timer = TimerFactory.CreateTimer(TimerType.Seconds, 0.01f);
        this.timer.TickEvent += (float obj) => { ShakeRandom(); };
        this.timer.ElapsedEvent += ReturnPosition;
        this.oldPos = this.mainCamera.transform.localPosition;
    }

    public void Shake()
    {
        this.timer.Start(0.2f);
    }

    void ShakeRandom()
    {
        this.mainCamera.transform.localPosition =
            this.mainCamera.transform.localPosition +
            (Random.insideUnitSphere * GameElementConstants.CameraShake);
    }

    Vector3 oldPos;

    void ReturnPosition()
    {
        this.mainCamera.transform.localPosition = oldPos;
    }
}
