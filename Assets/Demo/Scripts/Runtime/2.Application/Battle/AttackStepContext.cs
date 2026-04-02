namespace Demo.Domain
{
    public readonly ref struct AttackStepContext
    {
        public AttackStepContext(IAttacker attacker, IDefender defender)
        {
            _damage = new(attacker.AttackPower);
            _criticalCount = 0;
            _attacker = attacker;
            _defender = defender;
        }

        public AttackStepContext(float damage, in AttackStepContext context)
        {
            _damage = new(damage);
            _criticalCount = context._criticalCount;
            _attacker = context._attacker;
            _defender = context._defender;
        }

        public AttackStepContext(in AttackStepContext context)
        {
            _damage = context._damage;
            _criticalCount = context._criticalCount;
            _attacker = context._attacker;
            _defender = context._defender;
        }

        public Damage Damage => _damage;
        public int CriticalCount => _criticalCount;

        public IAttacker Attacker => _attacker;
        public IDefender Defender => _defender;

        private readonly Damage _damage;
        private readonly int _criticalCount;

        private readonly IAttacker _attacker;
        private readonly IDefender _defender;
    }
}
