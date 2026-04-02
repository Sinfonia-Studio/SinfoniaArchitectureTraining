using Demo.Adaptor;
using System;

namespace Demo.View
{
    public class UnitSpawnSignal : IUnitSpawnSignal
    {
        public Action<string[]> OnSpawn;

        public void InvokeSpawnUnit(string[] characterIDs)
        {
            OnSpawn?.Invoke(characterIDs);
        }
    }
}
