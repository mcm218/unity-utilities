public abstract class Stats {
    private readonly BaseStats     baseStats;
    private readonly StatsMediator mediator;

    public int Attack {
        get {
            var q = new Query(StatType.Attack, baseStats.attack);
            mediator.PerformQuery(this, q);
            return q.Value;
        }
    }

    public int Defense {
        get {
            var q = new Query(StatType.Defense, baseStats.defense);
            mediator.PerformQuery(this, q);
            return q.Value;
        }
    }

    public Stats(StatsMediator mediator, BaseStats baseStats) {
        this.mediator  = mediator;
        this.baseStats = baseStats;
    }
}