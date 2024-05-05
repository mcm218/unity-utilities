using System;
using System.Collections.Generic;

public class StatsMediator {
    private readonly LinkedList<StatModifier> modifiers = new();

    public event EventHandler<Query> Queries;
    public void                      PerformQuery(object sender, Query query) => Queries?.Invoke(sender, query);

    public void AddModifier(StatModifier modifier) {
        modifiers.AddLast(modifier);
        Queries += modifier.Handle;
        
        modifier.OnDispose += (modifier) => {
            modifiers.Remove(modifier);
            Queries -= modifier.Handle;
        };
    }
    
    public void Update (float deltaTime) {
        var node = modifiers.First;
        while (node != null) {
            var next = node.Next;
            node.Value.Update(deltaTime);
            node = next;
        }
        
        node = modifiers.First;
        while (node != null) {
            var next = node.Next;
            if (node.Value.MarkedForRemoval) {
                node.Value.Dispose();
            }
            node = next;
        }
    }
}