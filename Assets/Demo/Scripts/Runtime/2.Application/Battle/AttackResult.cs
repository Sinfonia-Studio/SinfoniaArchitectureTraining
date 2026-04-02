using Demo.Domain;

namespace Demo.Application
{
    public readonly struct AttackResult
    {
        public AttackResult(Damage damage, int criticalCount)
        {
            _damage = damage;
            _criticalCount = criticalCount;
        }

        public AttackResult(AttackStepContext context)
        {
            _damage = context.Damage;
            _criticalCount = context.CriticalCount;
        }

        public Damage Damage => _damage;
        public int CriticalCount => _criticalCount;

        private readonly Damage _damage;
        private readonly int _criticalCount;
    }
}
