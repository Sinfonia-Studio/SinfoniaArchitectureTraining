using UnityEngine;

namespace Demo.Adaptor
{
    public class CharacterPresenter
    {
        public CharacterPresenter(CharacterState state, ICharacterViewModel viewModel)
        {
            _state = state;
            _viewModel = viewModel;
        }

        public void Update()
        {
            CharacterDTO dto = new CharacterDTO(_state);
            _viewModel.Update(dto);
        }

        private readonly CharacterState _state;
        private readonly ICharacterViewModel _viewModel;
    }
}
