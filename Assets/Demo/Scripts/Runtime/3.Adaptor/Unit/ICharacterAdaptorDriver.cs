using Demo.Domain;

namespace Demo.Adaptor
{
    /// <summary>
    /// キャラクターのAdaptorを生成するファクトリインターフェース。
    /// </summary>
    public interface ICharacterAdaptorDriver
    {
        /// <summary>
        /// エンティティからAdaptorを生成する。
        /// </summary>
        /// <param name="entity">エンティティ</param>
        /// <returns>Adaptorコンテナ</returns>
        public CharacterAdaptor Create(CharacterEntity entity);
    }
}
