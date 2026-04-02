using Demo.Adaptor;
using System;

namespace Demo.View
{
    /// <summary>
    /// ユニット生成を通知するSignal。
    /// AdaptorからViewへイベントを仲介する。
    /// </summary>
    public class UnitSpawnSignal : IUnitSpawnSignal
    {
        /// <summary> ユニット生成時のイベント </summary>
        public event Action<UnitSpawnDTO> OnSpawn;

        /// <summary>
        /// ユニット生成を呼び出す。
        /// </summary>
        /// <param name="dto">生成情報のDTO</param>
        public void InvokeSpawnUnit(in UnitSpawnDTO dto)
        {
            OnSpawn?.Invoke(dto);
        }
    }
}
