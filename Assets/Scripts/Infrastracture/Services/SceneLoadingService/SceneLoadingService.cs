using TDS.Infrastracture.Locator;
using UnityEngine.SceneManagement;

namespace TDS.Infrastracture.Services.SceneLoadingService
{
    public class SceneLoadingService : IService
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}