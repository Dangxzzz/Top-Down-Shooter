using System;
using TDS.Infrastracture.Services;
using TDS.Infrastracture.Services.GamePlay;
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

        private GameplayService _gameplayService;
        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _gameplayService = ServiceLocator.Instance.Get<GameplayService>();
        }

        private void Start()
        {
            _gameplayService.OnHpOver += LoseScreen;
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
            _restartButton.onClick.AddListener(() =>
            {
                ServiceLocator.Instance.Get<StateMachine>().Enter<GameState>();
            });
        }

        private void OnDisable()
        {
           _gameplayService.OnHpOver -= LoseScreen;
        }

        #endregion

        #region Private methods

        private void LoseScreen()
        {
            _contextBox.gameObject.SetActive(true);
        }

        private void OnMainMenuButtonClick()
        {
            ServiceLocator.Instance.Get<StateMachine>().Enter<MenuState>();
        }

        #endregion
    }
}