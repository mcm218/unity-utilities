namespace _Scripts.Utilities.StatModifiers.Demo {
    public abstract class FalloutStatModifier {
        public bool MarkedForRemoval { get; private set; }
        
        public event System.Action<FalloutStatModifier> OnDispose = delegate { };
        
        readonly Utilities.CountdownTimer timer;
        
        protected FalloutStatModifier(float duration) {
            if (duration <= 0) return;
            
            timer             =  new Utilities.CountdownTimer(duration);
            timer.OnTimerStop += Dispose;
            timer.Start();
        }
        
        public void Update(float deltaTime) => timer?.Tick(deltaTime);
        
        public virtual void Handle(object sender, FalloutQuery query) { }
        
        public void Dispose() {
            MarkedForRemoval = true;
            OnDispose(this);
        }
    }
}