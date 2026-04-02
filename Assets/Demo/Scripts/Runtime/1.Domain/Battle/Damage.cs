using Demo.Utility;

namespace Demo.Domain
{
    public readonly struct Damage
    {
        public Damage(float value)
        {
            _value = value;
        }

        public float Value => _value;

        public static Health operator -(Health health, Damage damage)
        {
            return health - new Health(damage._value);
        }

        private readonly float _value;
    }
}
