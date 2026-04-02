using Demo.Adaptor;
using UnityEngine;
using System;

namespace Demo.View
{
    /// <summary>
    /// ユニット生成を表示するスポナーView。
    /// Adaptor層のIUnitSpawnerを実装し、Viewの実体を生成する。
    /// </summary>
    public class UnitSpawner : MonoBehaviour, IUnitSpawner
    {
        public void Bind(CharacterSpawner spawner)
        {
            _spawner = spawner;
        }

        [SerializeField, Tooltip("ユニット生成時の設定")]
        private UnitSpawnerConfig _config;

        private CharacterSpawner _spawner;

        /// <summary>
        /// キャラクターViewを生成し、コールバックに渡す。
        /// </summary>
        /// <param name="characterID">キャラクターID</param>
        /// <param name="onCreated">生成されたViewを渡すコールバック</param>
        public void SpawnCharacter(string characterID, Action<object> onCreated)
        {
            if (_spawner == null) { return; }

            float r = _config.SpawnRadius;
            float x = UnityEngine.Random.Range(-r, r);
            float z = UnityEngine.Random.Range(-r, r);
            Vector3 pos = transform.position + new Vector3(x, 0, z);

            CharacterView view = _spawner.SpawnCharacter(characterID, pos);
            onCreated?.Invoke(view);
        }

        private void OnValidate()
        {
            Debug.Assert(_config != null, $"{nameof(UnitSpawnerConfig)} is null", this);
        }

        private void OnDrawGizmos()
        {
            if (_config != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, _config.SpawnRadius);
            }
        }
    }
}
