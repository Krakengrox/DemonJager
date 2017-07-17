using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Behaviours.GamePlay
{
    public class GamePlayManager : Singleton<GamePlayManager>
    {
        public GamePlay gamePlay = null;

        public void Init()
        {
            //gamePlay.ResetScreens();
            this.gamePlay.Init();
        }
    }
}
