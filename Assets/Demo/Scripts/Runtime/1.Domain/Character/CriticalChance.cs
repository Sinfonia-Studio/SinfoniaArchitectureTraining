using System;
using UnityEngine;

namespace Demo.Domain
{
    public readonly struct CriticalChance
    {
        public CriticalChance(float value)
        {
            _value = Mathf.Clamp01(value);
        }

        public float Value => _value;

        public static bool operator <(CriticalChance left, float right) => left._value < right;
        public static bool operator >(CriticalChance left, float right) => left._value > right;

        private readonly float _value;
    }
}
