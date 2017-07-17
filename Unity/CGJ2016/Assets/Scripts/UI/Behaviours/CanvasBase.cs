using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Behaviours
{
    public class CanvasBase : MonoBehaviour
    {

        public void Toggle()
        {
            this.gameObject.SetActive(!this.gameObject.activeSelf);
        }

    }
}
