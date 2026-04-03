using Demo.Domain;

namespace Demo.Adaptor
{
    public readonly ref struct CharacterDTO
    {
        public CharacterDTO(CharacterState state)
        {
            _currentHealth = state.Entity.CurrentHealth.Value;
            _maxHealth = state.Entity.MaxHealth.Value;
        }

        public float CurrentHealth => _currentHealth;
        public float MaxHealth => _maxHealth;

        private readonly float _currentHealth;
        private readonly float _maxHealth;
    }
}
