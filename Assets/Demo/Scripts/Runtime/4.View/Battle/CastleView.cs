using UnityEngine;

namespace Demo.View
{
    /// <summary>
    ///     城（拠点）を表現するView。
    ///     ドメインモデルを直接は保持せず、初期化や更新はAdaptor層を通じて行う。
    /// </summary>
    public class CastleView : MonoBehaviour
    {
        [SerializeField, Tooltip("この城が所属する陣営のView")]
        private SideView _sideView;

        [SerializeField, Tooltip("初期体力")]
        private int _initialHealth = 1000;

        /// <summary> この城の座標。 </summary>
        public Vector3 Position => transform.position;

        /// <summary> この城の所属陣営のView。 </summary>
        public SideView SideView => _sideView;

        /// <summary> 初期体力。 </summary>
        public int InitialHealth => _initialHealth;
    }
}
