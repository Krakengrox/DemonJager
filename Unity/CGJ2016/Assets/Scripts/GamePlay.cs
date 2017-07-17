using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GamePlayTime : Singleton<GamePlayTime>
{
    #region Variables
    private bool isPaused;
    public bool IsPaused { get { return isPaused; } }
    public Action<bool> PausedEvent;

    #endregion

    public void Initialize()
    {
        this.isPaused = false;
    }


    public void SetPause(bool value)
    {
        this.isPaused = value;
        this.PausedEvent.Trigger(value);
    }
}