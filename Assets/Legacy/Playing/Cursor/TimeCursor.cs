using System;
using System.Timers;
using Misc;
using UnityEngine;

namespace Legacy.Playing.Cursor
{
    public class TimeCursor : Singleton<TimeCursor>
    {
        public int TicksPerSecond = 10;

        private float currentTime = 0f;

        private TriggerActivator _activator;

        public float CurrentTime
        {
            get => currentTime;
            set
            {
                if (value < 0) value = 0;
                currentTime = value;
                OnTick?.Invoke(currentTime);
                FixedUpdate();
            }
        }

        public TimeSpan Time => TimeSpan.FromSeconds(currentTime);

        public delegate void TimerEvent(float timer);

        public event TimerEvent OnTick;
        public event TimerEvent OnTimerMove;

        private Timer timer;

        public bool IsRunning => timer.Enabled;

        // Start is called before the first frame update
        void Start()
        {
            _activator = GetComponent<TriggerActivator>();
            _activator.enabled = false;
            Reset();
        }

        public void Play()
        {
            timer.Start();
            _activator.enabled = true;
        }

        public void Pause()
        {
            timer.Stop();
            _activator.enabled = false;
        }

        public void Reset()
        {
            transform.position = Vector3.zero;
            currentTime = 0f;
            timer?.Dispose();
            timer = new Timer(1000f / TicksPerSecond) {AutoReset = true};
            timer.Elapsed += TimerTick;
            _activator.enabled = false;
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            currentTime += 1f / TicksPerSecond;
            OnTick?.Invoke(currentTime);
            transform.position = Vector3.right * currentTime;
            OnTimerMove?.Invoke(currentTime);
        }

        public void ForceUpdate() => FixedUpdate();
        private void FixedUpdate()
        {
            transform.position = Vector3.right * currentTime;
            OnTimerMove?.Invoke(currentTime);
        }

        public void Restart()
        {
            Reset();
            timer.Start();
        }
    }
}
