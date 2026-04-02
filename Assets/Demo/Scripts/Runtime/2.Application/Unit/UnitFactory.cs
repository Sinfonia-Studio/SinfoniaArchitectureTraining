using Demo.Domain;
using System;

namespace Demo.Application
{
    /// <summary>
    /// ユニット生成を実行するファクトリ。
    /// </summary>
    public class UnitFactory
    {
        public UnitFactory(IUnitRepository unitRepository, ICharacterRepository characterRepository)
        {
            _unitRepository = unitRepository;
            _characterRepository = characterRepository;
        }

        /// <summary> キャラクターが生成された際に発火するイベント </summary>
        public event Action<CharacterEntity> OnCharacterSpawned;

        /// <summary>
        /// ユニットを生成する。
        /// </summary>
        /// <param name="unitID">生成するユニットのID</param>
        public void Spawn(UnitID unitID)
        {
            Unit unit = _unitRepository.GetUnit(unitID);

            foreach (CharacterID charaID in unit.IDs)
            {
                CharacterEntity entity = _characterRepository.GetCharacter(charaID);
                OnCharacterSpawned?.Invoke(entity);
            }
        }

        private readonly IUnitRepository _unitRepository;
        private readonly ICharacterRepository _characterRepository;
    }
}
