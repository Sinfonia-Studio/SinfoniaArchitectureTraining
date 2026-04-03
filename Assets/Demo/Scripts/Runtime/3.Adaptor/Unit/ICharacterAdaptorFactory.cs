namespace Demo.Adaptor
{
    /// <summary>
    /// キャラクターのAdaptorを生成するファクトリインターフェース。
    /// </summary>
    public interface ICharacterAdaptorFactory
    {
        /// <summary>
        /// エンティティからAdaptorを生成する。
        /// </summary>
        /// <param name="entity">エンティティ</param>
        /// <returns>Adaptorコンテナ</returns>
        CharacterAdaptor Create(Domain.CharacterEntity entity);
    }
}
