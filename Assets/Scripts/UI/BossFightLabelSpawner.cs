using DG.Tweening;
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
                ShowLabel();
            }
        }

        #endregion

        #region Private methods

        private void ShowLabel()
        {
            _label.DOFade(0f, 3f).OnComplete(() => gameObject.SetActive(false));
        }

        #endregion
    }
}