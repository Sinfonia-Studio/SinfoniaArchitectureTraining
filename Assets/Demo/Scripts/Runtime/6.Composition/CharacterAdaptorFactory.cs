using Demo.Adaptor;
using Demo.Domain;
using Demo.View;

namespace Demo.Composition
{
    /// <summary>
    /// キャラクターのAdaptorを生成する具体的なファクトリ。
    /// レイヤーを跨いで必要な各クラスをインスタンス化する。
    /// </summary>
    public class CharacterAdaptorFactory : ICharacterAdaptorFactory
    {
        /// <summary>
        /// エンティティから、各レイヤーのパーツ(State, VM, Presenter, Controller)を生成し、
        /// Adaptorコンテナにまとめて返す。
        /// </summary>
        public CharacterAdaptor Create(CharacterEntity entity)
        {
            // 1. 各レイヤーのパーツを生成
            CharacterState state = new(entity);
            CharacterViewModel viewModel = new(); // View層の実体
            CharacterPresenter presenter = new(state, viewModel);
            CharacterController controller = new(state, presenter);

            // 2. Adaptorコンテナとして返す
            return new CharacterAdaptor(viewModel, controller);
        }
    }
}
