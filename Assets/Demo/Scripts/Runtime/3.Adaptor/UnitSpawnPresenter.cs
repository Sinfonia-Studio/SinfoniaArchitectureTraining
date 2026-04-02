using Demo.Application;
using Demo.Domain;

namespace Demo.Adaptor
{
    /// <summary>
    /// ユニット生成のプレゼンター。
    /// Applicationの生成イベントをSignalへ変換する。
    /// </summary>
    public class UnitSpawnPresenter
    {
        public UnitSpawnPresenter(UnitFactory unitSpawner, IUnitSpawnSignal signal)
        {
            _unitSpawner = unitSpawner;
            _signal = signal;
            _unitSpawner.OnCharacterSpawned += OnCharacterSpawned;
        }

        private void OnCharacterSpawned(CharacterEntity[] characters)
        {
            string[] ids = new string[characters.Length];
            for (int i = 0; i < characters.Length; i++)
            {
                ids[i] = characters[i].CharacterID.Value;
            }

            _signal.InvokeSpawnUnit(new UnitSpawnDTO(ids));
        }

        private readonly UnitFactory _unitSpawner;
        private readonly IUnitSpawnSignal _signal;
    }
}
