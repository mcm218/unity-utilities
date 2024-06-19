using System;
using UnityEngine;

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
    
    public class IntCountdownTimer {
        public  Action OnTimerStop { get; set; }
        public  bool   IsRunning   { get; private set; }
        private int    ticksLeft;
        
        public int TicksLeft => ticksLeft;

        public IntCountdownTimer(int ticksLeft) {
            this.ticksLeft = ticksLeft;
        }

        public void Tick(int time) {
            if (ticksLeft <= 0 || !IsRunning) return;

            ticksLeft -= time;
            if (ticksLeft == 0) {
                OnTimerStop?.Invoke();
            }
        }

        public void Start() {
            IsRunning = true;
        }

        public void Pause() {
            IsRunning = false;
        }
    }
}