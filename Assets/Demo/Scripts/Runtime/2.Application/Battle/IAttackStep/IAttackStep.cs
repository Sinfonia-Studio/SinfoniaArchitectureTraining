using UnityEngine;

namespace Demo.Domain
{
    public interface IAttackStep
    {
        public AttackStepContext Execute(in AttackStepContext context);
    }
}
