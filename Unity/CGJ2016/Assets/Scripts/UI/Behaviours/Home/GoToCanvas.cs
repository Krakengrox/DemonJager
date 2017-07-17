using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

namespace UI.Behaviours.Home
{

    public class GoToCanvas : MonoBehaviour
    {
        public Button Story;
        public Button Survive;
        public Button CharacterButton;
        public Button BackToMain;
        public GameObject CharacterSelectCanvas;
        public Button ButtonLeaderBoard;
        //public Button ButtonAds;

        void Start()
        {
            Init();
        }

        public void Init()
        {
            //this.Story.onClick.AddListener(GameManager.Instance.GoToStoryMode);

            this.Survive.onClick.AddListener(GameManager.Instance.GoToSurviveMode);

            this.CharacterButton.onClick.AddListener(ActiveCharacterSelect);

            this.BackToMain.onClick.AddListener(ShutDownCharacterSelect);

            this.ButtonLeaderBoard.onClick.AddListener(ShowLeaderBoard);

            //this.ButtonAds.onClick.AddListener(CallAds);

        }

        public void ActiveCharacterSelect()
        {
            this.CharacterSelectCanvas.SetActive(true);
        }

        public void ShutDownCharacterSelect()
        {
            this.CharacterSelectCanvas.SetActive(false);

        }

        public void ShowLeaderBoard()
        {
            Social.ShowLeaderboardUI();
        }

    }

}
