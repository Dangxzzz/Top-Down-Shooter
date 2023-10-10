using TDS.Infrastracture.Services;
using TDS.Infrastracture.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _playButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        #endregion

        #region Private methods

        private void OnPlayButtonClicked()
        {
            ServiceLocator.Instance.Get<StateMachine>().Enter<GameState>();
        }

        #endregion
    }
}