using Demo.Adaptor;
using Demo.Application;
using Demo.Domain;
using Demo.InfraStructure;
using Demo.View;
using System;
using UnityEngine;

namespace Demo.Composition
{
    /// <summary>
    /// ユニット生成に関する依存性注入と初期化を行うクラス。
    /// ICharacterInitializer を実装し、生成されたエンティティとViewの橋渡しを行う。
    /// </summary>
    public class UnitInitializer : MonoBehaviour, ICharacterInitializer
    {
        [SerializeField, Tooltip("ユニットのリポジトリ")]
        private UnitRepository _unitRepository;
        [SerializeField, Tooltip("キャラクターのリポジトリ")]
        private CharacterRepository _characterRepository;
        [SerializeField, Tooltip("キャラクターViewのデータベース")]
        private CharacterViewDataBase _characterDataBase;
        [SerializeField, Tooltip("ユニットカードViewのリスト")]
        private UnitCardView[] _unitCardViews;
        [SerializeField]
        private UnitSpawner _unitSpawnerView;

        private void Awake()
        {
            // 1. レイヤー間のコンポーネント作成
            
            UnitFactory unitFactory = new(_unitRepository, _characterRepository);
            
            // Presenter が IUnitSpawner (View層) と ICharacterInitializer (Composition層) を介して動作する
            UnitSpawnPresenter spawnPresenter = new(unitFactory, _unitSpawnerView, this);
            UnitCardController cardController = new(unitFactory);

            // 2. Viewのバインド
            CharacterSpawner charaSpawner = new(_characterDataBase);
            _unitSpawnerView.Bind(charaSpawner);

            foreach (var cardView in _unitCardViews)
            {
                cardView.Bind(cardController);
            }
        }

        /// <summary>
        /// ICharacterInitializerの実装。
        /// 生成されたエンティティとViewを具体的な CharacterInitializer で初期化する。
        /// </summary>
        public void Initialize(CharacterEntity entity, object viewObject)
        {
            if (viewObject is CharacterView view)
            {
                CharacterInitializer.Initialize(entity, view);
            }
        }
    }
}
