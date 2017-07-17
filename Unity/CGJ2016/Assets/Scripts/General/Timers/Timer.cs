using System;
using System.Collections;
using UnityEngine;

namespace Timers
{
    public abstract class Timer
    {
        #region Variables

        #region Actions
        public Action ElapsedEvent;
        public Action<float> TickEvent;
        #endregion

        public float ElapsedTime { get { return elapsedTime; } }

        protected float elapsedTime = 0.0f;
        protected YieldInstruction waitFor = null;


        public abstract float Interval { get; }

        #region Pause

        private bool isPaused = false;

        public bool IsPaused
        {
            get { return isPaused; }
        }

        public bool IsRunning = false;
        #endregion
        #endregion

        #region Core
        public void Start(float interval)
        {
            TimerManager.Instance.StartCoroutine(TimerMechanism(interval));
        }

        IEnumerator TimerMechanism(float time)
        {
            this.IsRunning = true;

            this.elapsedTime = 0.0f;

            while (time > this.elapsedTime)
            {
                yield return waitFor;

                if (!this.isPaused)
                {
                    this.elapsedTime += Interval;
                    this.TickEvent.Trigger(this.elapsedTime);
                }
            }

            this.ElapsedEvent.Trigger();

            this.IsRunning = false;
        }
        #endregion

        #region Pause
        public void SetPause(bool value)
        {
            this.isPaused = value;
        }
        #endregion
    }
}