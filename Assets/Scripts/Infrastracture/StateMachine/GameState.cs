using TDS.Game.PlayerScripts;
using TDS.Infrastracture.Services;
using TDS.Infrastracture.Services.GamePlay;
using TDS.Infrastracture.Services.Input;
using TDS.Infrastracture.Services.LevelMenegmentService;
using TDS.Infrastracture.Services.Missions;
using TDS.Utillity;
using UnityEngine;

namespace TDS.Infrastracture.StateMachine
{
    public class GameState : AppState
    {
        #region Variables

        private PlayerMovement _playerMovement;

        #endregion

        #region Setup/Teardown

        public GameState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            LevelManagementService levelManagementService = ServiceLocator.Get<LevelManagementService>();
            levelManagementService.Initialize();
            levelManagementService.LoadCurrentLevel();

            ServiceLocator.Get<RunnerCourutine>().StartFrameTimer(1, InitAfterLoadScene);
        }

        public override void Exit()
        {
            _playerMovement.Dispose();
            
            Debug.LogError("GameState Exit");
            ServiceLocator.Get<MissionGameService>().Dispose();
            ServiceLocator.Get<GameplayService>().Dispose();
            ServiceLocator.Get<IInputService>().Dispose();
        }

        #endregion

        #region Private methods

        private void InitAfterLoadScene()
        {
            Debug.LogError($"GameState InitAfterLoadScene '{Time.frameCount}'");
            ServiceLocator.Get<MissionGameService>().Initialize();
            ServiceLocator.Get<GameplayService>().Initialize();
            
            _playerMovement = Object.FindObjectOfType<PlayerMovement>();
            Transform playerMovementTransform = _playerMovement.transform;

            IInputService inputService = ServiceLocator.Get<IInputService>();
            inputService.Initialize(Camera.main, playerMovementTransform);
            PlayerAttack _playerAttack = _playerMovement.GetComponent<PlayerAttack>();
            
            
            _playerMovement.Construct(inputService);
            _playerAttack.Construct(inputService);
        }

        #endregion
    }
}