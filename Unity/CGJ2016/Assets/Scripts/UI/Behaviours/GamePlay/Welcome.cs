using UnityEngine;
using System.Collections.Generic;
using System;

namespace UI.Behaviours.GamePlay
{
    public class Welcome : MonoBehaviour
    {
        #region Variables
        public Action TapEvent;

        GamePlayManager manager = null;

        #endregion

        #region Methods
        public void Init(Action Event)
        {
            this.manager = GamePlayManager.Instance;
            this.manager.gamePlay.TapScreen.TapEvent += Count;
        }

        void Count()
        {
            this.gameObject.SetActive(false);
            this.TapEvent.Trigger();
            this.manager.gamePlay.TapScreen.TapEvent -= Count;
        }

        #endregion
    }
}