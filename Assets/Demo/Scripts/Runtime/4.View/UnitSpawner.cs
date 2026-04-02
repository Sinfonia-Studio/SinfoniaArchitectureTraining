using UnityEngine;

namespace Demo.View
{
    public class UnitSpawner : MonoBehaviour
    {
        public void Bind(CharacterSpawner spawner, UnitSpawnSignal signal)
        {
            _spawner = spawner;
            _signal = signal;
            RegisterSignal(signal);
        }

        [SerializeField]
        private UnitSpawnerConfig _config;

        private CharacterSpawner _spawner;
        private UnitSpawnSignal _signal;

        private void OnDestroy()
        {
            UnregisterSignal(_signal);
        }

        private void RegisterSignal(UnitSpawnSignal signal)
        {
            if (_signal == null) { return; }
            signal.OnSpawn += SpawnUnit;
        }

        private void UnregisterSignal(UnitSpawnSignal signal)
        {
            if (_signal == null) { return; }
            signal.OnSpawn -= SpawnUnit;
        }

        private void SpawnUnit(string[] ids)
        {
            if (_spawner == null) { return; }

            float r = _config.SpawnRadius;

            foreach (string id in ids)
            {
                float x = Random.Range(-r, r);
                float z = Random.Range(-r, r);
                Vector3 pos = transform.position + new Vector3(x, 0, z);

                CharacterView view = _spawner.SpawnCharacter(id, pos);
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
