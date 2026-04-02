namespace Demo.Adaptor
{
    /// <summary>
    /// ユニット生成情報のDTO。
    /// </summary>
    public readonly struct UnitSpawnDTO
    {
        public UnitSpawnDTO(string[] characterIDs)
        {
            CharacterIDs = characterIDs;
        }

        /// <summary> キャラクターIDの配列 </summary>
        public readonly string[] CharacterIDs;
    }
}
