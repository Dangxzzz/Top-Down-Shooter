using TDS.Game.PlayerScripts;
using TDS.Infrastracture.Services;
using TDS.Infrastracture.Services.GamePlay;
using TDS.Infrastracture.Services.Input;
using TDS.Infrastracture.Services.LevelMenegmentService;
using TDS.Infrastracture.Services.SceneLoadingService;
using TDS.Infrastracture.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contextBox;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;


        #endregion

        #region Unity lifecycle

        public void Start()
        {
            ServiceLocator.Instance.Get<GameplayService>().OnHpOver += LoseScreen;
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
            _restartButton.onClick.AddListener(() =>
            {
                ServiceLocator.Instance.Get<LevelManagementService>().LoadCurrentLevel();
            });
        }

        public void OnDisable()
        {
            ServiceLocator.Instance.Get<GameplayService>().OnHpOver -= LoseScreen;
        }

        #endregion

        #region Private methods

        private void LoseScreen()
        {
            _contextBox.gameObject.SetActive(true);
        }

        private void OnMainMenuButtonClick()
        {
            ServiceLocator.Instance.Get<SceneLoadingService>().LoadScene(Scene.Menu);
            ServiceLocator.Instance.Get<GameplayService>().Initialize();
        }

        #endregion
    }
}