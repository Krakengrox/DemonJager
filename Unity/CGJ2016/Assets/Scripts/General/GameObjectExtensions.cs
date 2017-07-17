using System;
using System.Collections.Generic;

using UnityEngine;

public static class GameObjectExtensions
{

    public static T GetBehaviour<T>(this GameObject gameObject) where T : MonoBehaviour
    {
        T behaviour = null;

        behaviour = gameObject.GetComponent<T>();

        if (Equals(behaviour, null))
        {
            behaviour = gameObject.AddComponent<T>();
        }

        return behaviour;
    }

}
