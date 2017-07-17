using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Behaviours.GamePlay
{
    [Serializable]
    public class PowerUpMsg
    {
        #region Variables
        public GameObject Canvas;
        public Image Title;
        public Text Description;
        Ritual Ritual = null;
        Animator animator = null;
        bool state = false;
        #endregion


        public void Init()
        {
            animator = Canvas.GetComponent<Animator>();
            this.state = false;
            this.Canvas.SetActive(false);
            this.Ritual = PlayerManager.Instance.player.ritualPlayer;
            Ritual.ritualHud.SetActiveRitualEvent += PowerUpLauchedEventHandler;
        }

        void PowerUpLauchedEventHandler(bool state)
        {
            if (this.state != state)
            {
                this.state = state;
                if (state)
                {
                    this.Title.overrideSprite = GameElementConstants.RitualSprite[this.Ritual.powerUp.type];
                    this.Description.text = GameElementConstants.RitualDescription[this.Ritual.powerUp.type];
                    this.Canvas.SetActive(false);
                    this.Canvas.SetActive(true);
                }
                else
                {
                    this.animator.SetTrigger("out");
                }
            }
        }

    }
}
