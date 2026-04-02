using Demo.Domain;
using System;

namespace Demo.Application
{
    /// <summary>
    /// ユニット生成を実行するスポナー。
    /// </summary>
    public class UnitFactory
    {
        public UnitFactory(IUnitRepository unitRepository, ICharacterRepository characterRepository)
        {
            _unitRepository = unitRepository;
            _characterRepository = characterRepository;
        }

        /// <summary> キャラクターが生成された際に発火するイベント </summary>
        public event Action<CharacterEntity[]> OnCharacterSpawned;

        /// <summary>
        /// ユニットを生成する。
        /// </summary>
        /// <param name="unitID">生成するユニットのID</param>
        public void Spawn(UnitID unitID)
        {
            Unit unit = _unitRepository.GetUnit(unitID);

            CharacterEntity[] entities = new CharacterEntity[unit.IDs.Count];
            for (int i = 0; i < unit.IDs.Count; i++)
            {
                CharacterID charaID = unit.IDs[i];
                CharacterEntity entity = _characterRepository.GetCharacter(charaID);
                entities[i] = entity;
            }

            OnCharacterSpawned?.Invoke(entities);
        }

        private readonly IUnitRepository _unitRepository;
        private readonly ICharacterRepository _characterRepository;
    }
}
