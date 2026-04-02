using UnityEngine;

namespace Demo.Domain
{
    public readonly ref struct BattleStepContext
    {
        public BattleStepContext(CharacterEntity attacker, CharacterEntity defender)
        {
            _attacker = attacker;
            _defender = defender;
        }

        private readonly CharacterEntity _attacker;
        private readonly CharacterEntity _defender;
    }
}
