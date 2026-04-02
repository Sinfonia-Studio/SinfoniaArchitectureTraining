namespace Demo.Domain
{
    public class CharacterEntity : IAttacker, IDefender
    {
        public CharacterEntity(CharacterID id,
            Health health, 
            AttackPower power, 
            CriticalChance criticalChance,
            CriticalDamage criticalDamage)
        {
            _characterID = id;
            _healthEntity = new(health);
            _attackPower = power;
            _criticalChance = criticalChance;
            _criticalDamage = criticalDamage;
        }

        public CharacterID CharacterID => _characterID;
        public Health CurrentHealth => _healthEntity.CurrentHealth;
        public Health MaxHealth => _healthEntity.MaxHealth;
        public AttackPower AttackPower => _attackPower;
        public CriticalChance CriticalChance => _criticalChance;
        public CriticalDamage CriticalDamage => _criticalDamage;


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

        private readonly CharacterID _characterID;
        private readonly HealthEntity _healthEntity;
        private readonly AttackPower _attackPower;
        private readonly CriticalChance _criticalChance;
        private readonly CriticalDamage _criticalDamage;
    }
}
