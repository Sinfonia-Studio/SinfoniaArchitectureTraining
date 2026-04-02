namespace Demo.Domain
{
    public interface IAttacker
    {
        public AttackPower AttackPower { get; }
        public CriticalChance CriticalChance { get; }
        public CriticalDamage CriticalDamage { get; }
    }
}
