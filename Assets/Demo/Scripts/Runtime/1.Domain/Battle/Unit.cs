using System.Collections.Generic;

namespace Demo.Domain
{
    public readonly struct Unit
    {
        public Unit(UnitID id, CharacterID[] ids)
        {
            _id = id;
            _ids = ids;
        }

        public UnitID ID => _id;
        public IReadOnlyList<CharacterID> IDs => _ids;

        private readonly UnitID _id;
        private readonly CharacterID[] _ids;
    }
}
