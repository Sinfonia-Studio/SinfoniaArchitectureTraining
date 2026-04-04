namespace Demo.Adaptor
{
    /// <summary>
    /// キャラクターの準備が整ったことをView層へ通知するSignalインターフェース。
    /// </summary>
    public interface ICharacterSpawnSignal
    {
        /// <summary>
        /// キャラクターの準備完了を通知する。
        /// </summary>
        /// <param name="characterID">キャラクターID</param>
        /// <param name="adaptor">生成されたAdaptor</param>
        public void OnCharacterReady(string characterID, CharacterAdaptor adaptor);
    }
}
