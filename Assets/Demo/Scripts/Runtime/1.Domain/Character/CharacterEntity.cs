namespace Demo.Domain
{
    public class CharacterEntity : IAttackSpec, IDefenseSpec
    {
        public CharacterEntity(Health health, AttackPower power)
        {
            _healthEntity = new(health);
            _attackPower = power;
        }

        public Health CurrentHealth => _healthEntity.CurrentHealth;
        public Health MaxHealth => _healthEntity.MaxHealth;
        public AttackPower AttackPower => _attackPower;

        public void TakeDamage(Damage damage)
        {
            Health newHealth = _healthEntity.CurrentHealth - damage;
            _healthEntity.ChangeHealth(newHealth);
        }

        public void Heal(Health heal)
        {
            Health newHealth = _healthEntity.CurrentHealth + heal;
            _healthEntity.ChangeHealth(newHealth);
        }

        private readonly HealthEntity _healthEntity;
        private readonly AttackPower _attackPower;
    }
}
