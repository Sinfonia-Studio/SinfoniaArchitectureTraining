using Demo.Adaptor;
using Demo.Domain;
using Demo.InfraStructure;
using Demo.View;
using UnityEngine;
using CharacterController = Demo.Adaptor.CharacterController;

namespace Demo.Composition
{
    public static class CharacterInitializer
    {
        /// <summary>
        /// キャラクターの初期化と依存性注入を行う
        /// </summary>
        /// <param name="asset">キャラクターの基礎データ</param>
        /// <param name="view">キャラクターの表示側</param>
        public static void GenerateCharacter(CharacterAsset asset, CharacterView view)
        {
            CharacterEntity entity = asset.Get();

            CharacterState state = new(entity);

            CharacterViewModel viewModel = new();

            CharacterPresenter presenter = new(state, viewModel);
            CharacterController controller = new(state, presenter);

            view.Bind(viewModel, controller);
        }
    }
}
