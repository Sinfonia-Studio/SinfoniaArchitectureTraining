namespace Demo.Domain
{
    public readonly struct CharacterID
    {
        public CharacterID(string value) => _value = value;

        public string Value => _value;

        public static bool operator ==(CharacterID left, CharacterID right) => left._value == right._value;
        public static bool operator !=(CharacterID left, CharacterID right) => !(left == right);

        private readonly string _value;
    }
}
