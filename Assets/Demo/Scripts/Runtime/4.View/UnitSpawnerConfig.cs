using Demo.Utility;
using UnityEngine;

namespace Demo.View
{
    [CreateAssetMenu(fileName = nameof(UnitSpawnerConfig), 
        menuName = PathConst.CREATE_ASSET_MENU_PATH + nameof(UnitSpawnerConfig),
        order = 0)]
    public class UnitSpawnerConfig : ScriptableObject
    {
        public float SpawnRadius => _spawnRadius;

        [SerializeField, Min(0)]
        private float _spawnRadius = 1;
    }
}
