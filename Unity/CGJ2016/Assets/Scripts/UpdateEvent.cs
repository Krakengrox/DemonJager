using UnityEngine;
using System.Collections;
using System;

public class UpdateEvent : MonoBehaviour
{

    public Action updateEvent;

    void Update()
    {

        if (updateEvent != null)
            updateEvent();


    }
}
