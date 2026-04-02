using Demo.Domain;
using Demo.Application;

namespace Demo.Adaptor
{
    /// <summary>
    /// ユニット生成のプレゼンター。
    /// Applicationでのエンティティ生成時に、Viewを生成して初期化を行う。
    /// 依存性の逆転（DIP）により、View層やComposition層への直接の参照を持たない。
    /// </summary>
    public class UnitSpawnPresenter
    {
        public UnitSpawnPresenter(
            UnitFactory unitFactory, 
            IUnitSpawner unitSpawner,
            ICharacterInitializer characterInitializer)
        {
            _unitFactory = unitFactory;
            _unitSpawner = unitSpawner;
            _characterInitializer = characterInitializer;
            _unitFactory.OnCharacterSpawned += OnCharacterSpawned;
        }

        /// <summary>
        /// エンティティが生成された際のハンドラ。
        /// その場でView生成を要求し、生成直後のコールバックで初期化を完了させる。
        /// </summary>
        /// <param name="character">生成されたキャラクターエンティティ</param>
        private void OnCharacterSpawned(CharacterEntity character)
        {
            // View生成を要求。生成された瞬間に初期化を呼ぶ。
            _unitSpawner.SpawnCharacter(character.CharacterID.Value, (viewObject) =>
            {
                if (viewObject != null)
                {
                    _characterInitializer.Initialize(character, viewObject);
                }
            });
        }

        private readonly UnitFactory _unitFactory;
        private readonly IUnitSpawner _unitSpawner;
        private readonly ICharacterInitializer _characterInitializer;
    }
}
