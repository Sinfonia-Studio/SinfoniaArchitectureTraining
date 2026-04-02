using Demo.Adaptor;
using UnityEngine;

namespace Demo.View
{
    /// <summary>
    /// ユニット生成を表示するスポナーView。
    /// Adaptor層のICharacterSpawnSignalを実装し、キャラクターの論理的準備完了を受けてViewを生成する。
    /// </summary>
    public class UnitSpawner : MonoBehaviour, ICharacterSpawnSignal
    {
        public void Bind(CharacterSpawner spawner)
        {
            _spawner = spawner;
        }

        [SerializeField, Tooltip("ユニット生成時の設定")]
        private UnitSpawnerConfig _config;

        private CharacterSpawner _spawner;

        /// <summary>
        /// ICharacterSpawnSignalの実装。
        /// 論理的な準備が整ったキャラクターを、物理的なGameObjectとして生成しバインドする。
        /// </summary>
        /// <param name="characterID">キャラクターID</param>
        /// <param name="adaptor">論理的なパーツ一式</param>
        public void OnCharacterReady(string characterID, CharacterAdaptor adaptor)
        {
            if (_spawner == null) { return; }

            // 1. Viewを生成
            float r = _config.SpawnRadius;
            float x = Random.Range(-r, r);
            float z = Random.Range(-r, r);
            Vector3 pos = transform.position + new Vector3(x, 0, z);

            CharacterView view = _spawner.SpawnCharacter(characterID, pos);
            
            // 2. 受け取ったAdaptorをバインド
            if (view != null)
            {
                view.Bind(adaptor.ViewModel, adaptor.Controller);
            }
        }

        private void OnValidate()
        {
            Debug.Assert(_config != null, $"{nameof(UnitSpawnerConfig)} is null");
        }

        private void OnDrawGizmos()
        {
            if (_config != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireCube(transform.position, Vector3.one * _config.SpawnRadius);
            }
        }
    }
}
