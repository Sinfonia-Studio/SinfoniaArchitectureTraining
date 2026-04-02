using Demo.Domain;
using Demo.Utility;
using UnityEngine;

namespace Demo.InfraStructure
{
    [CreateAssetMenu(fileName = nameof(CharacterAsset),
        menuName = PathConst.CREATE_ASSET_MENU_PATH + nameof(CharacterAsset), 
        order = 0)]
    public class CharacterAsset : ScriptableObject
    {
        public CharacterEntity Get()
        {
            CharacterEntity character = new
                (
                    health: new(_health),
                    power: new(_attack),
                    criticalChance: new(_criticalChance),
                    criticalDamage: new(_criticalDamage)
                );
            return character;
        }

        [SerializeField, Min(0)]
        private float _health = 100;
        [SerializeField, Min(0)]
        private float _attack = 10;
        [SerializeField, Range(0, 1)]
        private float _criticalChance = 0.5f;
        [SerializeField, Min(1)]
        private float _criticalDamage = 2;
    }
}
