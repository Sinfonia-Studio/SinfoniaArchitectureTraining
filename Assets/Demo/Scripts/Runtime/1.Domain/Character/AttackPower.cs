namespace Demo.Domain
{
    public readonly struct AttackPower
    {
        public AttackPower(float value)
        {
            _value = value;
        }

        public float Value => _value;

        public static float operator *(AttackPower power, float multiplier)
        {
            return power._value * multiplier;
        }

        private readonly float _value;
    }
}
