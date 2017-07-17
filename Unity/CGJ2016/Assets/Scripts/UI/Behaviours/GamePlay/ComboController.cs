using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Timers;

namespace UI.Behaviours.GamePlay
{
    [Serializable]
    public class ComboController
    {
        #region Variable
        public GameObject comboNotification;
        public Text number;
        public Animator textComboCounterAnimator;
        public Animator comboNotificationAnimator;

        bool hidden = false;
        #endregion

        public void Init()
        {
            this.hidden = true;
            this.comboNotification.SetActive(false);
        }

        public void ComboEventHandler(int combos)
        {
            if (combos <= 0)
            {
                this.comboNotificationAnimator.SetTrigger("out");
                this.hidden = true;
            }
            else
            {
                if (this.hidden)
                {
                    this.comboNotification.SetActive(false);
                    this.comboNotification.SetActive(true);
                }

                this.number.text = combos.ToString();
                this.textComboCounterAnimator.SetTrigger("pop");
            }
        }
    }
}
