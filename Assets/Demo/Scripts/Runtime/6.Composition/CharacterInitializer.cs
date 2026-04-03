using Demo.Adaptor;
using Demo.Domain;
using Demo.InfraStructure;
using Demo.View;
using UnityEngine;
using CharacterController = Demo.Adaptor.CharacterController;

namespace Demo.Composition
{
    /// <summary>
    /// キャラクターの初期化を行うクラス。
    /// </summary>
    public static class CharacterInitializer
    {
        /// <summary>
        /// キャラクターの初期化と依存性注入を行う。
        /// </summary>
        /// <param name="asset">キャラクターの基礎データ</param>
        /// <param name="view">キャラクターの表示側</param>
        public static void GenerateCharacter(CharacterAsset asset, CharacterView view)
        {
            CharacterEntity entity = asset.Get();
            Initialize(entity, view);
        }

        /// <summary>
        /// 既存のエンティティを使用してキャラクターを初期化する。
        /// </summary>
        /// <param name="entity">キャラクターエンティティ</param>
        /// <param name="view">キャラクターの表示側</param>
        public static void Initialize(CharacterEntity entity, CharacterView view)
        {
            CharacterState state = new(entity);

            CharacterViewModel viewModel = new();

            CharacterPresenter presenter = new(state, viewModel);
            CharacterController controller = new(state, presenter);

            view.Bind(viewModel, controller);
        }
    }
}
