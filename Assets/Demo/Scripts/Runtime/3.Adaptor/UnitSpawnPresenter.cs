using Demo.Application;
using Demo.Domain;
using System;

namespace Demo.Adaptor
{
    /// <summary>
    /// ユニット生成のプレゼンター。
    /// Applicationでのエンティティ生成を受けて、Adaptorを作成しView層へ通知する。
    /// </summary>
    public class UnitSpawnPresenter : IDisposable
    {
        public UnitSpawnPresenter(
            UnitFactory unitFactory,
            ICharacterAdaptorDriver adaptorFactory,
            ICharacterSpawnSignal spawnSignal)
        {
            _unitFactory = unitFactory;
            _adaptorFactory = adaptorFactory;
            _spawnSignal = spawnSignal;
            _unitFactory.OnCharacterSpawned += OnCharacterSpawned;
        }

        public void Dispose()
        {
            if (_disposed) { return; }
            _unitFactory.OnCharacterSpawned -= OnCharacterSpawned;
            _disposed = true;
        }

        private readonly UnitFactory _unitFactory;
        private readonly ICharacterAdaptorDriver _adaptorFactory;
        private readonly ICharacterSpawnSignal _spawnSignal;
        private bool _disposed;

        /// <summary>
        /// エンティティが生成された際のハンドラ。
        /// 論理的なAdaptor一式を作成し、View層へ通知する。
        /// </summary>
        /// <param name="character">生成されたキャラクターエンティティ</param>
        private void OnCharacterSpawned(CharacterEntity character)
        {
            CharacterAdaptor adaptor = _adaptorFactory.Create(character);
            _spawnSignal.OnCharacterReady(character.CharacterID.Value, adaptor);
        }
    }
}
