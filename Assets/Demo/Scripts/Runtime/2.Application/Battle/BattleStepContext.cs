using UnityEngine;

namespace Demo.Domain
{
    public readonly ref struct BattleStepContext
    {
        public BattleStepContext(Character attacker, Character defender)
        {
            _attacker = attacker;
            _defender = defender;
        }

        private readonly Character _attacker;
        private readonly Character _defender;
    }
}
