namespace Demo.Adaptor
{
    /// <summary>
    /// キャラクターの論理的な機能をまとめたコンテナ。
    /// View層はこのオブジェクトを受け取って自身をバインドする。
    /// </summary>
    public class CharacterAdaptor
    {
        public CharacterAdaptor(ICharacterViewModel viewModel, CharacterController controller)
        {
            ViewModel = viewModel;
            Controller = controller;
        }

        /// <summary> 表示用データ保持クラス </summary>
        public ICharacterViewModel ViewModel { get; }
        
        /// <summary> 入力受付クラス </summary>
        public CharacterController Controller { get; }
    }
}
