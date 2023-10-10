using TDS.Infrastracture.Services;
using TDS.Infrastracture.Services.SceneLoadingService;
using UnityEngine;

namespace TDS.Infrastracture.StateMachine
{
    public class MenuState : AppState
    {
        #region Setup/Teardown

        public MenuState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            Debug.LogError("MenuState Enter");

            ServiceLocator.Get<SceneLoadingService>().LoadScene(Scene.Menu);
        }

        public override void Exit()
        {
            Debug.LogError("MenuState Exit");
        }

        #endregion
    }
}