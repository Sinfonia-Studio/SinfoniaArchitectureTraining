using UnityEngine;

namespace Demo.Adaptor
{
    public interface ICharacterViewModel
    {
        public void Update(in CharacterDTO dto);
    }
}
