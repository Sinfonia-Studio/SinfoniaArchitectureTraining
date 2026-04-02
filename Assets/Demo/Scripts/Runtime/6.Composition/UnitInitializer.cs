using Demo.Adaptor;
using Demo.Application;
using Demo.Domain;
using Demo.InfraStructure;
using Demo.View;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.Composition
{
    /// <summary>
    /// ユニット生成に関する依存性注入と初期化を行うクラス。
    /// </summary>
    public class UnitInitializer : MonoBehaviour
    {
        [SerializeField, Tooltip("ユニットのリポジトリ")]
        private UnitRepository _unitRepository;
        [SerializeField, Tooltip("キャラクターのリポジトリ")]
        private InfraStructure.CharacterRepository _characterRepository;
        [SerializeField, Tooltip("キャラクターViewのデータベース")]
        private CharacterViewDataBase _characterDataBase;
        [SerializeField, Tooltip("ユニットカードViewのリスト")]
        private UnitCardView[] _unitCardViews;
        [SerializeField]
        private UnitSpawner _unitSpawner;

        private void Awake()
        {
            // 1. レイヤー間のコンポーネント作成
            UnitSpawnSignal signal = new();
            
            UnitFactory unitSpawnerApp = new(_unitRepository, _characterRepository);
            
            UnitSpawnPresenter spawnPresenter = new(unitSpawnerApp, signal);
            UnitCardController cardController = new(unitSpawnerApp);

            // 2. Viewのバインド
            CharacterSpawner charaSpawner = new(_characterDataBase);
            _unitSpawner.Bind(charaSpawner, signal);

            foreach (var cardView in _unitCardViews)
            {
                cardView.Bind(cardController);
            }

            // 3. 生成されたキャラクターの初期化フロー
            unitSpawnerApp.OnCharacterSpawned += (entities) =>
            {
                foreach (var entity in entities)
                {
                    _spawnedEntities.Enqueue(entity);
                }
            };

            _unitSpawner.OnCharacterViewSpawned += (view, id) =>
            {
                if (_spawnedEntities.Count > 0)
                {
                    CharacterEntity entity = _spawnedEntities.Dequeue();
                    CharacterInitializer.Initialize(entity, view);
                }
            };
        }

        private readonly Queue<CharacterEntity> _spawnedEntities = new();
    }
}
