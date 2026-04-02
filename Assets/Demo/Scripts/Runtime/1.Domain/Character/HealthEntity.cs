using System;

namespace Demo.Domain
{
    public class HealthEntity
    {
        public HealthEntity(Health health)
        {
            if (health.Value < 0) { throw new ArgumentException(nameof(health), "Health cannot be negative."); }

            _health = health;
            _maxHealth = health;
        }

        public Health CurrentHealth => _health;
        public Health MaxHealth => _maxHealth;

        public void ChangeHealth(Health delta)
        {
            var newHealth = _health + delta;
            if (newHealth.Value < 0) { newHealth = new Health(0); }
            if (newHealth.Value > _maxHealth.Value) { newHealth = _maxHealth; }
            _health = newHealth;
        }

        private readonly Health _maxHealth;
        private Health _health;
    }
}
