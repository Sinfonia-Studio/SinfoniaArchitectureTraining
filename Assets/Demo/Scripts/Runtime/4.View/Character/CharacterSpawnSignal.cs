using Demo.Adaptor;
using System;

namespace Demo.View
{
    public class CharacterSpawnSignal : ICharacterSpawnSignal
    {
        public event Action<string, CharacterAdaptor> OnSpawnRequested;

        public void OnCharacterReady(string characterID, CharacterAdaptor adaptor)
        {
            OnSpawnRequested?.Invoke(characterID, adaptor);
        }
    }
}
