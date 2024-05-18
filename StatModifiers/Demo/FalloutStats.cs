namespace _Scripts.Utilities.StatModifiers.Demo {
    public class FalloutStats {
        private readonly FalloutBaseStats baseStats;
        private readonly FalloutStatsMediator    mediator;

        public FalloutStatsMediator Mediator => mediator;
        
        public int Strength {
            get {
                var q = new FalloutQuery(FalloutStatType.Strength, baseStats.strength);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }
        
        public int Perception {
            get {
                var q = new FalloutQuery(FalloutStatType.Perception, baseStats.perception);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }
        
        public int Endurance {
            get {
                var q = new FalloutQuery(FalloutStatType.Endurance, baseStats.endurance);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }
        
        public int Charisma {
            get {
                var q = new FalloutQuery(FalloutStatType.Charisma, baseStats.charisma);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }
        
        public int Intelligence {
            get {
                var q = new FalloutQuery(FalloutStatType.Intelligence, baseStats.intelligence);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }
        
        public int Agility {
            get {
                var q = new FalloutQuery(FalloutStatType.Agility, baseStats.agility);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }
        
        public int Luck {
            get {
                var q = new FalloutQuery(FalloutStatType.Luck, baseStats.luck);
                mediator.PerformQuery(this, q);
                return q.Value;
            }
        }
        
        public FalloutStats(FalloutStatsMediator mediator, FalloutBaseStats baseStats) {
            this.mediator  = mediator;
            this.baseStats = baseStats;
        }
    }
}