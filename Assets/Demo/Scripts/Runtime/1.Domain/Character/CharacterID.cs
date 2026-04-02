namespace Demo.Domain
{
    public readonly struct CharacterID
    {
        public CharacterID(string value) => _value = value;

        public string Value => _value;

        private readonly string _value;
    }
}
