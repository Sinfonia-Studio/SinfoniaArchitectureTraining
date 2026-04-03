using Demo.Domain;
using UnityEngine;

namespace Demo.Application
{
    public interface ICharacterRepository
    {
        public CharacterEntity GetCharacter(CharacterID id);
    }
}
