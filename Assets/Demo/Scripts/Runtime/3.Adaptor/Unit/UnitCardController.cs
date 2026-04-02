using Demo.Domain;

namespace Demo.Adaptor
{
    /// <summary>
    /// ユニットカードの入力を管理するコントローラー。
    /// </summary>
    public class UnitCardController
    {
        public UnitCardController(Application.UnitFactory unitSpawner)
        {
            _unitSpawner = unitSpawner;
        }

        /// <summary>
        /// ユニットを生成する。
        /// </summary>
        /// <param name="unitID">生成するユニットのID</param>
        public void SpawnUnit(string unitID)
        {
            _unitSpawner.Spawn(new(unitID));
        }

        private readonly Application.UnitFactory _unitSpawner;
    }
}
