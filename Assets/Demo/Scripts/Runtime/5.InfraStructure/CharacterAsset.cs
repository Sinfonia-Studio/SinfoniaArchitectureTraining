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

        [SerializeField]
        private float _health;
        [SerializeField]
        private float _attack;
        [SerializeField]
        private float _criticalChance;
        [SerializeField]
        private float _criticalDamage;
    }
}
