using System;
using System.Collections.Generic;
using UnityEngine;

namespace General.UnityMessages
{
    public class OnTriggerEnterMessage : MonoBehaviour
    {

        public Action<Collider> action;

        void OnTriggerEnter(Collider other)
        {
            action.Trigger(other);
        }

    }
}
