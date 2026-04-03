using Demo.Domain;

namespace Demo.Application
{
    public static class AttackExecutor
    {
        public static AttackResult Execute(AttackPipeline pipeline, CharacterEntity attacker, CharacterEntity defender)
        {
            AttackResult result = AttackCalculator.Calculate(pipeline, attacker, defender);
            defender.TakeDamage(result.Damage);
            return result;
        }
    }
}
