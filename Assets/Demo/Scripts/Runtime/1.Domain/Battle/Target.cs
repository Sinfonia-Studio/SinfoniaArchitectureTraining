using UnityEngine;

namespace Demo.Domain
{
    /// <summary>
    ///     ターゲット情報を保持する値オブジェクト（構造体）。
    ///     データ指向的な走査を可能にするため、軽量に保つ。
    /// </summary>
    public readonly struct Target
    {
        public Target(Vector3 position, Side side)
        {
            _position = position;
            _side = side;
        }

        /// <summary> 現在座標。 </summary>
        public Vector3 Position => _position;

        /// <summary> 所属陣営。 </summary>
        public Side Side => _side;

        private readonly Vector3 _position;
        private readonly Side _side;
    }
}
