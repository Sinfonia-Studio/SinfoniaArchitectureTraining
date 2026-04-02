namespace Demo.Domain
{
    public readonly ref struct AttackStepContext
    {
        public AttackStepContext(IAttackSpec attacker, IDefenseSpec defender)
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

        public Damage Damage => _damage;
        public int CriticalCount => _criticalCount;

        private readonly Damage _damage;
        private readonly int _criticalCount;

        private readonly IAttackSpec _attacker;
        private readonly IDefenseSpec _defender;
    }
}
