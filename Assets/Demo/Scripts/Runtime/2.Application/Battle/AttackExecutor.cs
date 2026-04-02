using Demo.Domain;

namespace Demo.Application
{
    public static class AttackExecutor
    {
        public static void Execute(AttackPipeline pipeline, CharacterEntity attacker, CharacterEntity defender)
        {
            AttackStepContext context = new(attacker, defender);
            foreach (IAttackStep attackStep in pipeline.AttackSteps)
            {
                context = attackStep.Execute(context);
            }

            defender.TakeDamage(context.Damage);
        }
    }
}
