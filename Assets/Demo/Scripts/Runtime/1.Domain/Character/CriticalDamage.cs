using UnityEngine;

namespace Demo.Domain
{
    public readonly struct CriticalDamage
    {
        public CriticalDamage(float value) => _value = value;

        public float Value => _value;

        private readonly float _value;
    }
}
