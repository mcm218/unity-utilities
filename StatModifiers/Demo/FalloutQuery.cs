namespace _Scripts.Utilities.StatModifiers.Demo {
    public class FalloutQuery {
        public readonly FalloutStatType StatType;
        public          int             Value;
        
        public FalloutQuery(FalloutStatType statType, int value) {
            StatType = statType;
            Value    = value;
        }
    }
}