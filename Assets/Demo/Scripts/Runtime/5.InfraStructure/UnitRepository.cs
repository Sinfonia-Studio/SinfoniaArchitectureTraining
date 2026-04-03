using Demo.Application;
using Demo.Domain;
using Demo.Utility;
using System;
using UnityEngine;

namespace Demo.InfraStructure
{
    /// <summary>
    /// ユニットのリポジトリ。
    /// ScriptableObjectからデータを取得する。
    /// </summary>
    [CreateAssetMenu(fileName = nameof(UnitRepository), 
        menuName = PathConst.CREATE_ASSET_MENU_PATH + nameof(UnitRepository), 
        order = 0)]
    public class UnitRepository : ScriptableObject, IUnitRepository
    {
        /// <summary>
        /// IDからユニットを取得する。
        /// </summary>
        /// <param name="id">ユニットID</param>
        /// <returns>ユニット</returns>
        public Unit GetUnit(UnitID id)
        {
            UnitAsset asset = Array.Find(_units, x => x.GetUnit().ID.Value == id.Value);
            return asset != null ? asset.GetUnit() : default;
        }

        [SerializeField, Tooltip("ユニットアセットの配列")]
        private UnitAsset[] _units;
    }
}
