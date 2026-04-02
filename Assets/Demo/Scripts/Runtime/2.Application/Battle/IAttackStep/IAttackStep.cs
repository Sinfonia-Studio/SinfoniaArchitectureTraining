using UnityEngine;

namespace Demo.Domain
{
    public interface IAttackStep
    {
        public AttackStepContext Excecute(in AttackStepContext context);
    }
}
