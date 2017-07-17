using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Behaviours.GamePlay
{
    public class Pause : CanvasBase
    {
        public Button Resume;
        public Button GoToHome;
        public Button GoToSurvive;
        public Button MuteSFx;
        public Button MuteSound;
        public Text Score;

        GameManager gameManager = null;
        void Start()
        {
            Init();
        }

        public void Init()
        {
            gameManager = GameManager.Instance;
            //configure buttons
            this.GoToHome.onClick.AddListener(this.gameManager.GoToHome);
            this.GoToSurvive.onClick.AddListener(this.gameManager.GoToSurviveMode);
        }

    }
}
