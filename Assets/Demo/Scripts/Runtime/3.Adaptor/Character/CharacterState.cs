using Demo.Domain;

namespace Demo.Adaptor
{
    public class CharacterState
    {
        public CharacterState(CharacterEntity entity)
        {
            _entity = entity;
        }

        public CharacterEntity Entity => _entity;

        private readonly CharacterEntity _entity;
    }
}
