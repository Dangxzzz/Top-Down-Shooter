using System;
using TDS.Infrastracture.Services;
using TDS.Infrastracture.Services.GamePlay;
using UnityEngine;
using UnityEngine.Serialization;

namespace TDS.UI
{
    public class GameUiMediator : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverScreen;

        private GameplayService _gameplayService;

        private void Awake()
        {
            _gameplayService = ServiceLocator.Instance.Get<GameplayService>();
            _gameOverScreen.gameObject.SetActive(false);
        }

        public void Start()
        {
            _gameplayService.OnHpOver += OnHpOver;
        }

        public void OnDestroy()
        {
            _gameplayService.OnHpOver -= OnHpOver;
        }

        private void OnHpOver()
        {
            _gameOverScreen.gameObject.SetActive(true);
        }
    }
}
