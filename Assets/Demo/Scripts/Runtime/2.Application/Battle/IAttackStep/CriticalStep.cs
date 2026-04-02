using Demo.Domain;
using UnityEngine;

namespace Demo.Application
{
    public class CriticalStep : IAttackStep
    {
        public AttackStepContext Execute(in AttackStepContext context)
        {
            float rand = Random.Range(0f, 1f);
            if (context.Attacker.CriticalChance > rand)
            {
                float damage = context.Damage.Value * context.Attacker.CriticalDamage.Value;
                return new AttackStepContext(damage, context);
            }

            return new AttackStepContext(context);
        }
    }
}
