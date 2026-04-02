using Demo.Utility;

namespace Demo.Domain
{
    public class CharacterEntity
    {
        public CharacterEntity(Health health)
        {
            _health = new(health);
        }

        public HealthEntity HealthEntity => _health;

        public void TakeDamage(Health damage)
        {
            Health newHealth = _health.CurrentHealth - damage;
            _health.ChangeHealth(newHealth);
        }

        public void Heal(Health heal)
        {
            Health newHealth = _health.CurrentHealth + heal;
            _health.ChangeHealth(newHealth);
        }

        private readonly AttackSpec _attackSpec;
        private readonly DefenseSpec _defenseSpec;
        private readonly HealthEntity _health;
    }
}
