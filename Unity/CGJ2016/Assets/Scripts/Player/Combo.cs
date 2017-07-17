using System;
using System.Collections.Generic;
using Timers;
using UnityEngine;

public class Combo
{

    #region Variables

    enum State
    {
        Delay,
        Combo
    }

    int delayCombos = 2;
    float tiempoParaQuitarLosCombos = 0.0f;
    int combos = 0;

    State state = State.Delay;

    int matches = 0;

    public Action<int> ComboEvent;

    GameObject view = null;
    #endregion

    public void matchEventHandler()
    {
        switch (this.state)
        {
            case State.Delay:
                if (matches >= delayCombos)
                {
                    this.matches = 0;
                    this.state = State.Combo;
                    this.combos = delayCombos;
                    goto case State.Combo;
                }
                matches++;
                break;
            case State.Combo:
                this.combos++;
                this.ComboEvent.Trigger(this.combos);
                break;
        }
    }

    public void missEventHandler()
    {
        switch (this.state)
        {
            case State.Delay:
                this.matches = 0;
                break;
            case State.Combo:
                this.state = State.Delay;
                this.combos = 0;
                this.ComboEvent.Trigger(0);
                break;
            default:
                break;
        }
    }

}