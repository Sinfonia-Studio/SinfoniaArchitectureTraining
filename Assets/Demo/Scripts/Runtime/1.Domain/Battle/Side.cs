using System;

namespace Demo.Domain
{
    /// <summary>
    ///     陣営を定義する値オブジェクト（構造体）。
    ///     名前そのものが同一であれば同一の陣営として扱う。
    /// </summary>
    public readonly struct Side : IEquatable<Side>
    {
        public Side(string name)
        {
            _name = name ?? string.Empty;
        }

        /// <summary> 陣営名。 </summary>
        public string Name => _name;

        /// <summary> 陣営が正しく定義されているか。 </summary>
        public bool IsDefined => !string.IsNullOrEmpty(_name);

        public bool Equals(Side other) => _name == other._name;
        public override bool Equals(object obj) => obj is Side other && Equals(other);
        public override int GetHashCode() => _name?.GetHashCode() ?? 0;

        public static bool operator ==(Side left, Side right) => left.Equals(right);
        public static bool operator !=(Side left, Side right) => !left.Equals(right);

        private readonly string _name;
    }
}
