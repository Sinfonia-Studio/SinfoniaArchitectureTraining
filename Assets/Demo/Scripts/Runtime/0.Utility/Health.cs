using System;

namespace Demo.Utility
{
    public readonly struct Health : IEquatable<Health>, IComparable<Health>
    {
        public Health(float value)
        {
            _value = value;
        }

        public float Value => _value;

        public bool Equals(Health other) => _value.Equals(other._value);
        public int CompareTo(Health other) => _value.CompareTo(other._value);

        public static bool operator ==(Health left, Health right) => left._value == right._value;
        public static bool operator !=(Health left, Health right) => left._value != right._value;

        public static Health operator +(Health left, Health right) => new(left._value + right._value);

        public override bool Equals(object obj) => obj is Health other && Equals(other);

        private readonly float _value;
    }
}
