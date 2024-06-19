namespace _Scripts.Utilities {
    public class Observable<T> {
        public T Value {
            get => value;
            set {
                if (value.Equals(this.value)) return;

                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        T value;

        public event System.Action<T> OnValueChanged;

        public Observable(T value) => Value = value;
    }
}