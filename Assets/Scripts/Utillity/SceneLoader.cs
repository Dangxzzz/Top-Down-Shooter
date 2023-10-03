using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Utillity
{
    public class SceneLoader : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _timeToRestart;

        #endregion

        #region Public methods

        public void LoadNextlevelTimer()
        {
            this.StartTimer(_timeToRestart, LoadNextLevel);
        }
        
        #endregion

        #region Private methods

        private void LoadNextLevel()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}