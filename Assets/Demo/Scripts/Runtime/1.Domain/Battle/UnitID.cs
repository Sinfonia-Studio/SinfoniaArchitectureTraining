using UnityEngine;

namespace Demo.Domain
{
    public readonly struct UnitID
    {
        public UnitID(string value) => _value = value;

        public string Value => _value;

        private readonly string _value;
    }
}
