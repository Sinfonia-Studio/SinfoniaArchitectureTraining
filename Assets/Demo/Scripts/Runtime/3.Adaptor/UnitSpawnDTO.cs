namespace Demo.Adaptor
{
    /// <summary>
    /// ユニット生成（キャラクター単位）の情報のDTO。
    /// </summary>
    public readonly struct UnitSpawnDTO
    {
        public UnitSpawnDTO(string characterID)
        {
            CharacterID = characterID;
        }

        /// <summary> キャラクターID </summary>
        public readonly string CharacterID;
    }
}
