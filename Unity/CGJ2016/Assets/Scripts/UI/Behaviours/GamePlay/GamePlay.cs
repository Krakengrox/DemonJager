using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;


namespace UI.Behaviours.GamePlay
{
    public class GamePlay : MonoBehaviour
    {
        GamePlayManager manager = null;
        public Tap TapScreen;
        public Welcome WelcomeScreen;
        public HUD HUDScreen;
        public GameOver GameOverScreen;
        public Pause PauseScreen;

        public void Awake()
        {
            this.manager = GamePlayManager.Instance;

            this.manager.gamePlay = this;
        }

        public void Init()
        {
            ConfigureWelcome();
            ConfigHUD();
            ConfigPause();
            ResetScreens();
        }

        public void ResetScreens()
        {
            //set canvases enabled states.
            this.GameOverScreen.gameObject.SetActive(false);
            this.HUDScreen.gameObject.SetActive(false);
            this.TapScreen.gameObject.SetActive(true);
            this.WelcomeScreen.gameObject.SetActive(true);
            this.PauseScreen.gameObject.SetActive(false);
        }

        public void StartGamePlay()
        {
            //set canvases enabled states.
            this.GameOverScreen.gameObject.SetActive(false);
            this.HUDScreen.gameObject.SetActive(true);
            this.TapScreen.gameObject.SetActive(true);
            this.WelcomeScreen.gameObject.SetActive(true);
            this.PauseScreen.gameObject.SetActive(false);
        }

        void ConfigHUD()
        {
            this.HUDScreen.Initialize();
            this.HUDScreen.Pause.onClick.AddListener(this.PauseScreen.Toggle);
        }

        #region Welcome Screen

        void ConfigureWelcome()
        {
            this.WelcomeScreen.TapEvent += WelcomeScreenTappedEventHandler;
        }

        void WelcomeScreenTappedEventHandler()
        {
            this.WelcomeScreen.TapEvent -= WelcomeScreenTappedEventHandler;
            this.HUDScreen.gameObject.SetActive(true);
        }

        #endregion

        void ConfigPause()
        {
            //resume the game the game.
            this.PauseScreen.Resume.onClick.AddListener(this.HUDScreen.Pause.onClick.Invoke);
        }
    }
}
