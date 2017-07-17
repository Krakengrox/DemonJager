using UnityEngine;

namespace Timers
{
    public class SecondsTimer : Timer
    {
        private float interval = 0.0f;
        public override float Interval { get { return interval; } }


        public SecondsTimer(float interval = 1.0f)
        {
            this.interval = interval;
            this.waitFor = new WaitForSeconds(interval);
        }

    }
}
