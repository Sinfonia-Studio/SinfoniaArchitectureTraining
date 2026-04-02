using Demo.Domain;

namespace Demo.Adaptor
{
    /// <summary>
    /// キャラクターの表示側の生成を担うインターフェース。
    /// Adaptor層に定義され、View層が実装する。
    /// </summary>
    public interface IUnitSpawner
    {
        /// <summary>
        /// 指定されたキャラクターIDのViewを生成する。
        /// </summary>
        /// <param name="characterID">キャラクターID</param>
        /// <param name="onCreated">生成された際に呼ばれるコールバック</param>
        void SpawnCharacter(string characterID, System.Action<object> onCreated);
    }

    /// <summary>
    /// キャラクターの初期化を担うインターフェース。
    /// Adaptor層に定義され、Composition層が実装する。
    /// </summary>
    public interface ICharacterInitializer
    {
        /// <summary>
        /// キャラクターのエンティティとViewを紐付ける。
        /// </summary>
        /// <param name="entity">エンティティ</param>
        /// <param name="viewObject">Viewオブジェクト（内部でキャストして使用）</param>
        void Initialize(CharacterEntity entity, object viewObject);
    }
}
