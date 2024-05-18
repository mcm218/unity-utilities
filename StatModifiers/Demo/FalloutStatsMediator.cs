using System;
using System.Collections.Generic;

namespace _Scripts.Utilities.StatModifiers.Demo {
    public class FalloutStatsMediator {
        private readonly LinkedList<FalloutStatModifier> modifiers = new();
        
        public event EventHandler<FalloutQuery> Queries;
        
        public void PerformQuery(object sender, FalloutQuery query) => Queries?.Invoke(sender, query);
        
        public void AddModifier(FalloutStatModifier modifier) {
            modifiers.AddLast(modifier);
            Queries += modifier.Handle;
            
            modifier.OnDispose += (disposedModifier) => {
                modifiers.Remove(disposedModifier);
                Queries -= disposedModifier.Handle;
            };
        }

        public void Update(float deltaTime) {
            var node = modifiers.First;
            while (node != null) {
                var next = node.Next;
                node.Value.Update(deltaTime);
                node = next;
            }

            node = modifiers.First;
            while (node != null) {
                var next = node.Next;
                if (node.Value.MarkedForRemoval) { node.Value.Dispose(); }
                node = next;
            }
        }
    }
}