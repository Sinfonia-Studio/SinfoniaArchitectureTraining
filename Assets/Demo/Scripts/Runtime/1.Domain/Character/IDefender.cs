namespace Demo.Domain
{
    public interface IDefender
    {
        public Health CurrentHealth { get; }
        public Health MaxHealth { get; }
    }
}
