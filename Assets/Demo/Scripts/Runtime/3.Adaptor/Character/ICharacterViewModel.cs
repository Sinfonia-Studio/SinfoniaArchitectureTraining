using System;
using UnityEngine;

namespace Demo.Adaptor
{
    public interface ICharacterViewModel : IDisposable
    {
        public void Update(in CharacterDTO dto);
    }
}
