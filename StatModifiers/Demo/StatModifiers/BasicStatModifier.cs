using System;
using _Scripts.Utilities.Enums;
using UnityEngine;

namespace _Scripts.Utilities.StatModifiers.Demo.StatModifiers {
    public class BasicStatModifier : FalloutStatModifier {
        [SerializeField] private FalloutStatType type;
        [SerializeField]
        private Func<int, int> operation;

        public BasicStatModifier(FalloutStatType type, float duration, Func<int, int> operation) : base(duration) {
            this.type      = type;
            this.operation = operation;
        }
        
        public override void Handle(object sender, FalloutQuery query) {
            if (query.StatType == type) {
                query.Value = operation(query.Value);
            }
        }
    }
}