using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Behaviours.Home
{
    public class Home : MonoBehaviour
    {
        public bool deletePlayerpref = false;
        public GoToCanvas goToCanvas;
        public Options Options;
        public CharacterSelectHud CharactersSelect;
        public Text HighScore;
        public Text TotalSouls;

        void Start()
        {
            Init();
        }

        void Init()
        {
            this.HighScore.text = DataService.Instance.GetUserData().HighScore.ToString();
            this.TotalSouls.text = DataService.Instance.GetUserData().Souls.ToString();
        }

        void Update()
        {
            if (deletePlayerpref)
                PlayerPrefs.DeleteAll();
        }
    }

}
