namespace Demo.Adaptor
{
    /// <summary>
    /// ユニット生成を通知するSignalインターフェース。
    /// </summary>
    public interface IUnitSpawnSignal
    {
        /// <summary>
        /// ユニット生成を呼び出す。
        /// </summary>
        /// <param name="dto">生成情報のDTO</param>
        public void InvokeSpawnUnit(in UnitSpawnDTO dto);
    }
}
