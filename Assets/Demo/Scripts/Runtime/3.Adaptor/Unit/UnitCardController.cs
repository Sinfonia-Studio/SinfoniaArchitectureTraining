using Demo.Domain;
using Demo.Application;

namespace Demo.Adaptor
{
    /// <summary>
    /// ユニットカードの入力を管理するコントローラー。
    /// </summary>
    public class UnitCardController
    {
        public UnitCardController(UnitFactory unitFactory)
        {
            _unitFactory = unitFactory;
        }

        /// <summary>
        /// ユニットを生成する。
        /// </summary>
        /// <param name="unitID">生成するユニットのID</param>
        public void SpawnUnit(string unitID)
        {
            _unitFactory.Spawn(new(unitID));
        }

        private readonly UnitFactory _unitFactory;
    }
}
