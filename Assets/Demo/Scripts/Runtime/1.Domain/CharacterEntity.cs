using Demo.Utility;
using UnityEngine;

namespace Demo.Domain
{
    public class CharacterEntity
    {
        public CharacterEntity(Health health)
        {
            _health = new(health);
        }

        private readonly HealthEntity _health;
    }
}
