using Demo.Utility;
using UnityEngine;

namespace Demo.Domain
{
    public class Character
    {
        public Character(Health health)
        {
            _health = new(health);
        }

        private readonly HealthEntity _health;
    }
}
