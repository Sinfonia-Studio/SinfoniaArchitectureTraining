using Demo.Adaptor;
using UnityEngine;
using CharacterController = Demo.Adaptor.CharacterController;

namespace Demo.View
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private Transform _model;

        public void Bind(CharacterViewModel viewModel, CharacterController controller)
        {
            _viewModel = viewModel;
            _controller = controller;
        }

        private void OnDestroy()
        {
            _viewModel?.Dispose();
        }

        private CharacterViewModel _viewModel;
        private CharacterController _controller;
    }
}
