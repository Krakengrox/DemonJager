using System;
using System.Collections.Generic;
using UnityEngine;

namespace General.UnityMessages
{
    public class OnTriggerExitMessage : MonoBehaviour
    {

        public Action<Collider> action;

        void OnTriggerExit(Collider other)
        {
            action.Trigger(other);
        }

    }
}
