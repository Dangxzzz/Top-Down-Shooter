using TDS.Game.PlayerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Utillity
{
    public class SceneLoader : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerDeath _playerDeath;
        [SerializeField] private float _timeToRestart;

        #endregion

        #region Unity lifecycle
        
        private void OnEnable()
        {
            _playerDeath.OnHappened += RestartScene;
        }

        private void OnDisable()
        {
            _playerDeath.OnHappened -= RestartScene;
        }

        #endregion

        #region Private methods

        private void RestartScene()
        {
            this.StartTimer(_timeToRestart, ReloadScene);
        }
        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}