using Demo.Adaptor;
using Demo.Application;
using Demo.Domain;
using Demo.View;
using UnityEngine;
using CharacterController = Demo.Adaptor.CharacterController;

namespace Demo.Composition
{
    /// <summary>
    /// キャラクターのAdaptorを生成する具体的なファクトリ。
    /// レイヤーを跨いで必要な各クラスをインスタンス化する。
    /// </summary>
    public class CharacterAdaptorDriver : ICharacterAdaptorDriver
    {
        public CharacterAdaptorDriver(CharacterMovementService movementService, ICharacterRepository repository)
        {
            _movementService = movementService;
            _repository = repository;
        }

        /// <summary>
        /// エンティティから、各レイヤーのパーツ(State, VM, Presenter, Controller)を生成し、
        /// Adaptorコンテナにまとめて返す。
        /// </summary>
        public CharacterAdaptor Create(CharacterEntity entity, Vector3 position)
        {
            // 1. 各レイヤーのパーツを生成
            CharacterState state = new(entity, position);
            CharacterViewModel viewModel = new(); // View層の実体
            CharacterPresenter presenter = new(state, viewModel);
            CharacterController controller = new(state, presenter, _movementService, _repository);

            // 2. Adaptorコンテナとして返す
            return new CharacterAdaptor(viewModel, controller);
        }

        private readonly CharacterMovementService _movementService;
        private readonly ICharacterRepository _repository;
    }
}
