using Demo.Adaptor;
using Demo.Utility;
using System;

namespace Demo.View
{
    public class CharacterViewModel : ICharacterViewModel, IDisposable
    {
        public IReadOnlyReactiveProperty<float> CurrentHealth => _currentHealth;
        public IReadOnlyReactiveProperty<float> MaxHealth => _maxHealth;

        private readonly ReactiveProperty<float> _currentHealth = new(1);
        private readonly ReactiveProperty<float> _maxHealth = new(1);

        public void Update(in CharacterDTO dto)
        {
            _currentHealth.Value = dto.CurrentHealth;
            _maxHealth.Value = dto.MaxHealth;
        }

        public void Dispose()
        {
            _currentHealth.Dispose();
            _maxHealth.Dispose();
        }
    }
}
