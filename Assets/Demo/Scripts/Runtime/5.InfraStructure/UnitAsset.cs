using Demo.Domain;
using Demo.Utility;
using UnityEngine;

namespace Demo.InfraStructure
{
    [CreateAssetMenu(fileName = nameof(UnitAsset),
        menuName = PathConst.CREATE_ASSET_MENU_PATH + nameof(UnitAsset), 
        order = 0)]
    public class UnitAsset : ScriptableObject
    {
        public Unit GetUnit()
        {
            CharacterID[] ids = new CharacterID[_characterAsset.Length];
            for (int i = 0; i < _characterAsset.Length; i++) { ids[i] = _characterAsset[i].Id; }
            return new(new(_id), ids);
        }

        [SerializeField]
        private string _id = string.Empty;

        [SerializeField]
        private CharacterAsset[] _characterAsset;
    }
}
