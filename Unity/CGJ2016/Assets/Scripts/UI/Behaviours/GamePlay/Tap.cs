using UnityEngine;
using System.Collections.Generic;
using System;

namespace UI.Behaviours.GamePlay
{
    public class Tap : MonoBehaviour
    {
        #region Variables
        public GameObject panel;
        public Action TapEvent
        {
            get { return pointerDown.Action; }
            set { pointerDown.Action = value; }
        }
        OnPointerDownMessage pointerDown = null;
        #endregion

        #region Methods
        void Awake()
        {
            Init();
        }

        public void Init()
        {
            this.pointerDown = this.panel.GetBehaviour<OnPointerDownMessage>();
        }

        #endregion

    }
}