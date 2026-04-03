using Demo.Domain;

namespace Demo.Application
{
    /// <summary>
    /// ユニットのリポジトリインターフェース。
    /// </summary>
    public interface IUnitRepository
    {
        /// <summary>
        /// IDからユニットを取得する。
        /// </summary>
        /// <param name="id">ユニットID</param>
        /// <returns>ユニット</returns>
        public Unit GetUnit(UnitID id);
    }
}
