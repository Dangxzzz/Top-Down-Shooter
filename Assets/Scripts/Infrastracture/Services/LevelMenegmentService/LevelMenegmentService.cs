using TDS.Infrastracture.Locator;
using UnityEngine;

namespace TDS.Infrastracture.Services.LevelMenegmentService
{
    public class LevelManagementService : IService
    {
        #region Variables

        private const string ConfigPath = "Configs/LevelManagementServiceConfig";

        private readonly SceneLoadingService.SceneLoadingService _sceneLoadingService;

        private LevelManagementServiceConfig _config;
        private int _currentSceneIndex;
        private bool _isConfigLoaded;

        #endregion

        #region Setup/Teardown

        public LevelManagementService(SceneLoadingService.SceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
        }

        #endregion

        #region Public methods

        public void IncrementLevel()
        {
            _currentSceneIndex++;
        }

        public void Initialize()
        {
            LoadConfig();
        }

        public bool IsCurrentLevelExists()
        {
            return _config.SceneNames.Length > _currentSceneIndex;
        }

        public void LoadCurrentLevel()
        {
            if (_config == null)
            {
                Debug.Log($"error {_config.name}");
            }
            _sceneLoadingService.LoadScene(_config.SceneNames[_currentSceneIndex]);
        }

        #endregion

        #region Private methods

        private void LoadConfig()
        {
            if (_isConfigLoaded)
            {
                return;
            }

            _config = Resources.Load<LevelManagementServiceConfig>(ConfigPath);
            _isConfigLoaded = true;
        }

        #endregion
    }
}