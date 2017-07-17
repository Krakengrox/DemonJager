using UnityEngine;

namespace Timers
{
    public class FixedUpdateTimer : Timer
    {
        public override float Interval { get { return Time.fixedDeltaTime; } }

        public FixedUpdateTimer()
        {
            this.waitFor = new WaitForFixedUpdate();
        }
    }
}
