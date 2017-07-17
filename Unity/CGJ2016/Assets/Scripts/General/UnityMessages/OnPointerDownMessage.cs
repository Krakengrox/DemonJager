using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class OnPointerDownMessage : MonoBehaviour, IPointerDownHandler
{
    public Action Action;

    public void OnPointerDown(PointerEventData eventData)
    {
        Action.Trigger();
    }
}
