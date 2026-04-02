using Demo.Domain;
using UnityEngine;

namespace Demo.Application
{
    public static class AttackCalculator
    {
            public static AttackResult Calculate(AttackPipeline pipeline, IAttacker attacker, IDefender defender)
            {
                AttackStepContext context = new(attacker, defender);
                foreach (IAttackStep attackStep in pipeline.AttackSteps)
                {
                    context = attackStep.Execute(context);
                }
    
                return new AttackResult(context);
        }
    }
}
