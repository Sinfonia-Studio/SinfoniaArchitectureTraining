using UnityEngine;

namespace Demo.View
{
    /// <summary>
    ///     陣営を定義するView。
    ///     インスタンスごとに異なる陣営を表現することで拡張性を確保する。
    ///     Domain層は参照せず、あくまでシーン内での識別子として機能する。
    /// </summary>
    public class SideView : MonoBehaviour
    {
        [SerializeField, Tooltip("陣営名（識別子）")]
        private string _sideName;

        /// <summary> 陣営名を取得する。 </summary>
        public string SideName => _sideName;
    }
}
