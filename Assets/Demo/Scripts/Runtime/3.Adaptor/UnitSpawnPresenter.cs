using Demo.Domain;
using Demo.Application;
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
            ICharacterAdaptorFactory adaptorFactory,
            ICharacterSpawnSignal spawnSignal)
        {
            _unitFactory = unitFactory;
            _adaptorFactory = adaptorFactory;
            _spawnSignal = spawnSignal;
            _unitFactory.OnCharacterSpawned += OnCharacterSpawned;
        }

        /// <summary>
        /// エンティティが生成された際のハンドラ。
        /// 論理的なAdaptor一式を作成し、View層へ通知する。
        /// </summary>
        /// <param name="character">生成されたキャラクターエンティティ</param>
        private void OnCharacterSpawned(CharacterEntity character)
        {
            // 1. 論理的なパーツ(Adaptor)を生成
            CharacterAdaptor adaptor = _adaptorFactory.Create(character);
            
            // 2. View層へ通知
            _spawnSignal.OnCharacterReady(character.CharacterID.Value, adaptor);
        }

        private readonly UnitFactory _unitFactory;
        private readonly ICharacterAdaptorFactory _adaptorFactory;
        private readonly ICharacterSpawnSignal _spawnSignal;
        private bool _disposed;

        public void Dispose()
        {
            if (_disposed) return;
            _unitFactory.OnCharacterSpawned -= OnCharacterSpawned;
            _disposed = true;
        }
    }
}
