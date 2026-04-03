using Demo.Utility;
using System;
using UnityEngine;

namespace Demo.View
{
    [CreateAssetMenu(fileName = nameof(CharacterViewDataBase),
        menuName = PathConst.CREATE_ASSET_MENU_PATH + nameof(CharacterViewDataBase),
        order = 0)]
    public class CharacterViewDataBase : ScriptableObject
    {
        public bool TryGetCharacterView(string id, out CharacterView view)
        {
            CharacterData data = Array.Find(_characterDataBase, data => data.ID == id);
            view = data.View;
            return view != null;
        }

        [SerializeField]
        private CharacterData[] _characterDataBase;

        [Serializable]
        private struct CharacterData
        {
            public string ID => _id;
            public CharacterView View => _view;

            [SerializeField]
            private string _id;
            [SerializeField]
            private CharacterView _view;
        }
    }
}
