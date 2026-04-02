using System;
using System.Buffers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Demo.View
{
    public class CharacterSpawner
    {
        public CharacterSpawner(CharacterViewDataBase characterDataBase)
        {
            _characterDataBase = characterDataBase;
        }

        public CharacterView SpawnCharacter(string id, Vector3 position = default, Transform parent = null)
        {
            if (!_characterDataBase.TryGetCharacterView(id, out CharacterView view)) { return null; }
            CharacterView chara = Object.Instantiate(view, position, Quaternion.identity, parent);
            return chara;
        }

        private CharacterViewDataBase _characterDataBase;
    }
}
