using System;

namespace Demo.Utility
{
    public interface IReadOnlyReactiveProperty<out T>
    {
        T Value { get; }
        void Subscribe(Action<T> action);
        void Unsubscribe(Action<T> action);
    }

    public class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>, IDisposable
    {
        public ReactiveProperty(T initialValue)
        {
            _value = initialValue;
        }

        public T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value)) return;
                _value = value;
                _onChanged?.Invoke(_value);
            }
        }

        private T _value;
        private Action<T> _onChanged;

        public void Subscribe(Action<T> action)
        {
            _onChanged += action;
            action?.Invoke(_value);
        }

        public void Unsubscribe(Action<T> action)
        {
            _onChanged -= action;
        }

        public void Dispose()
        {
            _onChanged = null;
        }
    }
}
