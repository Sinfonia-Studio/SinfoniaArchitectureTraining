using UnityEngine;

namespace Demo.Domain
{
    public readonly ref struct AttackStepContext
    {
        public AttackStepContext(CharacterEntity attacker, CharacterEntity defender)
        {
            _damage = 0;
            _criticalCount = 0;
            _attacker = attacker;
            _defender = defender;
        }

        public AttackStepContext(float damage, in AttackStepContext context)
        {
            _damage = damage;
            _criticalCount = context._criticalCount;
            _attacker = context._attacker;
            _defender = context._defender;
        }

        private readonly float _damage;
        private readonly int _criticalCount;

        private readonly CharacterEntity _attacker;
        private readonly CharacterEntity _defender;
    }
}
