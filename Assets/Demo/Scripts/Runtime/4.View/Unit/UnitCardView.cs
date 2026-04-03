using Demo.Adaptor;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.View
{
    /// <summary>
    /// ユニットカードの表示と入力を管理するView。
    /// </summary>
    public class UnitCardView : MonoBehaviour
    {
        public void Bind(UnitCardController controller)
        {
            _controller = controller;
        }

        [SerializeField, Tooltip("ユニットID")]
        private string _unitID;
        [SerializeField, Tooltip("生成ボタン")]
        private Button _spawnButton;

        private UnitCardController _controller;

        private void Start()
        {
            if (_spawnButton != null)
            {
                _spawnButton.onClick.AddListener(OnClickSpawn);
            }
        }

        private void OnDestroy()
        {
            if (_spawnButton != null)
            {
                _spawnButton.onClick.RemoveListener(OnClickSpawn);
            }
        }

        private void OnClickSpawn()
        {
            _controller?.SpawnUnit(_unitID);
        }
    }
}
