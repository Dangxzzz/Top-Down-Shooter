using TDS.Infrastracture.Services;
using TDS.Infrastracture.Services.GamePlay;
using TDS.Infrastracture.Services.Input;
using TDS.Infrastracture.Services.LevelMenegmentService;
using TDS.Infrastracture.Services.Missions;
using TDS.Infrastracture.Services.SceneLoadingService;
using Unity.VisualScripting;
using UnityEngine;

namespace TDS.Infrastracture.StateMachine
{
    public class BootstrapState : AppState
    {
        #region Setup/Teardown

        public BootstrapState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            Debug.LogError("BootstrapState Enter");

            SceneLoadingService sceneLoadingService = new();
            ServiceLocator.Register(sceneLoadingService);
            MissionGameService missionGameService = new();
            ServiceLocator.Register(missionGameService);
            LevelManagementService levelManagementService = new(sceneLoadingService);
            ServiceLocator.Register(levelManagementService);
            ServiceLocator.RegisterMonoBeh<RunnerCourutine>();
            ServiceLocator.Register(new GameplayService(missionGameService, levelManagementService, StateMachine, sceneLoadingService));
#if UNITY_STANDALONE
            ServiceLocator.Register<IInputService>(new StandaloneInputService());
#elif UNITY_ANDROID || UNITY_IOS
           //TODO: DANYA MAKE MOBILEINPUTSERVICE
#endif
            StateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {
            Debug.LogError("BootstrapState Exit");
        }

        #endregion
    }

}