using Demo.Utility;
using Demo.Application;
using Demo.Domain;
using UnityEngine;
using System;

namespace Demo.InfraStructure
{
    [CreateAssetMenu(fileName = nameof(CharacterRepository),
        menuName = PathConst.CREATE_ASSET_MENU_PATH + nameof(CharacterRepository),
        order = 0)]
    public class CharacterRepository : ScriptableObject, ICharacterRepository
    {
        public CharacterEntity GetCharacter(CharacterID id)
        {
            CharacterAsset asset = Array.Find(_characters, asset => asset.Id == id);
            return asset.Get();
        }

        [SerializeField]
        private CharacterAsset[] _characters;
    }
}
