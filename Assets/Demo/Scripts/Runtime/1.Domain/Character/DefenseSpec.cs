namespace Demo.Domain
{
    public interface IDefenseSpec
    {
        public Health CurrentHealth { get; }
        public Health MaxHealth { get; }
    }
}
