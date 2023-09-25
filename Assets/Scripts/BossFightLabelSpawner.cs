using TMPro;
using UnityEngine;

namespace TDS
{
    public class BossFightLabelSpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _label;
        private bool _isActive;

        #endregion

        #region Properties

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_isActive)
            {
                Debug.Log("ER");
                ShowLabel();
            }
        }

        #endregion

        #region Private methods

        private void ShowLabel()
        {
            Color labelColor = _label.color; 
            labelColor.a -= 0.001f;
            _label.color = labelColor;
            if (labelColor.a <= 0)
            {
                gameObject.SetActive(false);
                _isActive = false;
            }
        }

        #endregion
    }
}