
namespace Timers
{
    public class TimerFactory
    {
        public static Timer CreateTimer(TimerType type = TimerType.EndOfFrame, float interval = 1.0f)
        {
            switch (type)
            {
                case TimerType.Seconds:
                    return new SecondsTimer(interval);
                case TimerType.EndOfFrame:
                    return new EndOfFrameTimer();
                case TimerType.FixedUpdate:
                    return new FixedUpdateTimer();
                default:
                    return new EndOfFrameTimer();
            }
        }

    }
}