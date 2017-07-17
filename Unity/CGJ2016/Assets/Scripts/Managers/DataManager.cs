using UnityEngine;
using System.Collections.Generic;
using System;

public class DataManager : Singleton<DataManager>
{
    #region Variables
    public bool isInitialized = false;
    ScenesManager sceneManager = null;

    public Action initializedEvent;
    #endregion

    #region Methods
    protected override void Awake()
    {
        this.isPersistent = true;
        base.Awake();

        //catch singletons
        this.sceneManager = ScenesManager.Instance;

    }

    public void Initialize()
    {
        this.isInitialized = true;

        this.initializedEvent.Trigger();
    }

    #endregion
}
