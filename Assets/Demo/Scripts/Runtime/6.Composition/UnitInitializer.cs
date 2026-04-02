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
    /// 状態を持たず、各レイヤーを接続する役割のみを持つ。
    /// </summary>
    public class UnitInitializer : MonoBehaviour
    {
        [SerializeField, Tooltip("ユニットのリポジトリ")]
        private UnitRepository _unitRepository;
        [SerializeField, Tooltip("キャラクターのリポジトリ")]
        private CharacterRepository _characterRepository;
        [SerializeField, Tooltip("キャラクターViewのデータベース")]
        private CharacterViewDataBase _characterDataBase;
        [SerializeField, Tooltip("ユニットカードViewのリスト")]
        private UnitCardView[] _unitCardViews;
        [SerializeField, Tooltip("プレイヤーのスポナー")]
        private UnitSpawner _spawner;

        // Presenter のライフサイクル管理のためフィールドで保持
        private Demo.Adaptor.UnitSpawnPresenter _spawnPresenter;

        private void Awake()
        {
            // 1. 各レイヤーのコンポーネントを接続            
            UnitFactory unitFactory = new(_unitRepository, _characterRepository);
            
            // Adaptor層のファクトリとSignalを利用してPresenterを初期化
            CharacterAdaptorFactory adaptorFactory = new();
            _spawnPresenter = new(unitFactory, adaptorFactory, _spawner);
            
            UnitCardController cardController = new(unitFactory);

            // 2. Viewへのバインド（静的な紐付け）
            CharacterSpawner charaSpawner = new(_characterDataBase);
            _spawner.Bind(charaSpawner);

            foreach (var cardView in _unitCardViews)
            {
                cardView.Bind(cardController);
            }
        }

        private void OnDestroy()
        {
            _spawnPresenter?.Dispose();
        }
    }
}
