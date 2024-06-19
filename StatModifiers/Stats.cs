using Sirenix.Serialization;
using System;

internal class Stats {
    [OdinSerialize]
    private BaseStats     baseStats;
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
    
    public int SpecialAttack {
        get {
            var q = new Query(StatType.SpecialAttack, baseStats.spAtk);
            mediator.PerformQuery(this, q);
            return q.Value;
        }
    }
    
    public int SpecialDefense {
        get {
            var q = new Query(StatType.SpecialDefense, baseStats.spDef);
            mediator.PerformQuery(this, q);
            return q.Value;
        }
    }
    
    public int Speed {
        get {
            var q = new Query(StatType.Speed, baseStats.speed);
            mediator.PerformQuery(this, q);
            return q.Value;
        }
    }
    
    public int HP {
        get {
            var q = new Query(StatType.HP, baseStats.hp);
            mediator.PerformQuery(this, q);
            return q.Value;
        }
    }

    public Stats(StatsMediator mediator, BaseStats baseStats) {
        this.mediator  = mediator;
        this.baseStats = baseStats;
    }
}