using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        #endregion

        #region Events

        public event Action OnRestartButtonClick;

        #endregion

        #region Unity lifecycle

        public void Start()
        {
            gameObject.SetActive(false);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
            _restartButton.onClick.AddListener(() =>
            {
                if (OnRestartButtonClick != null)
                {
                    OnRestartButtonClick.Invoke();
                }
            });
        }

        #endregion

        #region Private methods

        private void OnMainMenuButtonClick()
        {
            Debug.Log("MainMenu");
        }

        #endregion
    }
}