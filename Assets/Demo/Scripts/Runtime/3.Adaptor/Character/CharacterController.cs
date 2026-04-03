using UnityEngine;

namespace Demo.Adaptor
{
    public class CharacterController
    {
        public CharacterController(CharacterState state, CharacterPresenter presenter)
        {
            _state = state;
            _presenter = presenter;
        }

        private readonly CharacterState _state;
        private readonly CharacterPresenter _presenter;
    }
}
