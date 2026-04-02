using Demo.Domain;
using Demo.InfraStructure;
using Demo.View;
using System;
using UnityEngine;

namespace Demo.Composition
{
    [RequireComponent(typeof(UnitSpawner))]
    public class UnitInitializer : MonoBehaviour
    {
        [SerializeField] private UnitAsset[] _unit;
        [SerializeField] private CharacterViewDataBase _characterDataBase;

        private void Awake()
        {
            UnitSpawner unitSpawner = GetComponent<UnitSpawner>();
            UnitSpawnSignal signal = new();

            CharacterSpawner spawner = new(_characterDataBase);

            unitSpawner.Bind(spawner, signal);
        }
    }
}
