namespace Demo.Domain
{
    /// <summary>
    ///     城（拠点）を定義するドメインエンティティ。
    /// </summary>
    public class CastleEntity : IDefender
    {
        public CastleEntity(Health health)
        {
            _healthEntity = new HealthEntity(health);
        }

        public Health CurrentHealth => _healthEntity.CurrentHealth;
        public Health MaxHealth => _healthEntity.MaxHealth;
        public Side Side => _side;

        /// <summary> 陣営を設定する。 </summary>
        public void SetSide(Side side)
        {
            _side = side;
        }

        public void TakeDamage(Damage damage)
        {
            _healthEntity.ChangeHealth(new Health(-damage.Value));
        }

        private readonly HealthEntity _healthEntity;
        private Side _side;
    }
}
