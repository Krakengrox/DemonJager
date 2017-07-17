using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Advertisements;

namespace UI.Behaviours.GamePlay
{
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public Text HighScore;
        public Button GoToHomeBtn;
        public Button GoToSurvive;
        public Button ShareBtn;
        GameManager gameManager = null;
        public Text SacrificeCount;
        public Button revive;
        #endregion

        #region Methods
        void Awake()
        {
            Init();
        }

        void Init()
        {
            this.gameManager = GameManager.Instance;
            this.GoToHomeBtn.onClick.AddListener(GoToHome);
            this.GoToSurvive.onClick.AddListener(Replay);
            this.ShareBtn.onClick.AddListener(Share);
            this.revive.onClick.AddListener(PlayAdvertisement);
            AdsManager.Instance.finishVideo += FinishedVideo;
            AdsManager.Instance.skipedVideo += FinishedVideo;
            AdsManager.Instance.errorVideo += ErrorVideo;


        }

        public void ReviveVerification()
        {
            if (!PlayerManager.Instance.player.iRevive & AdsManager.Instance.AdvertisementIsReady())
            {
                revive.gameObject.SetActive(true);
            }
            else
            {
                revive.gameObject.SetActive(false);
            }

        }
        void GoToHome()
        {
            this.gameManager.GoToHome();
        }

        void Replay()
        {
            this.gameManager.GoToSurviveMode();
        }

        void Share()
        {
            StartCoroutine(AndroidShare.SaveAndShare(Initializer.Instance.sacrificeCounts.sacrificeCount));
        }

        void PlayAdvertisement()
        {
            AdsManager.Instance.LaunchAdvertisement();
        }

        void FinishedVideo()
        {
            PlayerManager.Instance.player.Lives = 3;
            this.gameObject.SetActive(false);
            GamePlayTime.Instance.SetPause(false);
            PlayerManager.Instance.player.iRevive = true;

        }

        void ErrorVideo()
        {

        }
        #endregion
    }
}