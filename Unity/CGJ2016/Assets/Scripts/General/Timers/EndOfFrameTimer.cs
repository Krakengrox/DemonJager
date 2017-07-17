using UnityEngine;

namespace Timers
{
    public class EndOfFrameTimer : Timer
    {
        public override float Interval { get { return Time.deltaTime; } }


        public EndOfFrameTimer()
        {
            this.waitFor = new WaitForEndOfFrame();
        }

    }
}
