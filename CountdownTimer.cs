using System;

namespace _Scripts.Utilities {
    public class CountdownTimer {
        public  Action OnTimerStop { get; set; }
        public  bool   IsRunning   { get; private set; }
        private float  duration;

        public CountdownTimer(float duration) {
            this.duration = duration;
        }

        public void Tick(float deltaTime) {
            if (duration <= 0 || !IsRunning) return;

            duration -= deltaTime;
            if (duration <= 0) { OnTimerStop?.Invoke(); }
        }

        public void Start() {
            IsRunning = true;
        }

        public void Pause() {
            IsRunning = false;
        }
    }
}