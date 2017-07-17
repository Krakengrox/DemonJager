using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

namespace UI.Behaviours.GamePlay
{
    public class HUD : MonoBehaviour
    {
        #region Variables
        global::GamePlayTime gamePlay = null;

        public Button Pause;
        public Text Score;

        public GameObject[] lives;
        public Button ActivatePowerUp;
        public GameObject PowerUpGlowEffect;
        public GameObject PowerUpIcon;

        public ComboController ComboNotification;

        public PowerUpMsg PoweUpMessage;
        #endregion

        #region Methods

        public void Initialize()
        {
            this.gamePlay = global::GamePlayTime.Instance;
            //configure button pause;
            this.Pause.onClick.AddListener(TogglePause);
            this.ComboNotification.Init();
            this.PoweUpMessage.Init();
        }

        void TogglePause()
        {
            this.gamePlay.SetPause(!this.gamePlay.IsPaused);

        }

        public void playerLivesEventHandler(int lives)
        {

            lives--;

            for (int i = this.lives.Length - 1; i >= 0; i--)
            {
                if (i <= lives)
                {
                    this.lives[i].SetActive(true);
                }
                else
                {
                    this.lives[i].SetActive(false);
                }
            }
        }

        #endregion
    }
}