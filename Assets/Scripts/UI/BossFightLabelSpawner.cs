using DG.Tweening;
using TMPro;
using UnityEngine;

namespace TDS.UI
{
    public class BossFightLabelSpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _label;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            ShowLabel();
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