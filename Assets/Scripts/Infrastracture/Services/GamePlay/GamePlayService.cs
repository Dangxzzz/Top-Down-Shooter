﻿using System;
using SPL.Editor;
using TDS.Infrastracture.Locator;
using TDS.Infrastracture.Services.LevelMenegmentService;
using TDS.Infrastracture.Services.Missions;
using TDS.Infrastracture.StateMachine;
using Unity.VisualScripting;
using UnityEngine;
using Scene = TDS.Infrastracture.Services.SceneLoadingService.Scene;

namespace TDS.Infrastracture.Services.GamePlay
{
    public class GameplayService : IService
    {
        #region Variables

        private readonly LevelManagementService _levelManagementService;
        private readonly StateMachine.StateMachine _stateMachine;
        private readonly MissionGameService _missionGameService;
        private readonly SceneLoadingService.SceneLoadingService _sceneLoadingService;

        private float _currentHp;

        public event Action OnHpOver;
        #endregion

        #region Setup/Teardown

        public GameplayService(MissionGameService missionGameService, LevelManagementService levelManagementService,
            StateMachine.StateMachine stateMachine,SceneLoadingService.SceneLoadingService sceneLoadingService)
        {
            _missionGameService = missionGameService;
            _levelManagementService = levelManagementService;
            _stateMachine = stateMachine;
            _sceneLoadingService = sceneLoadingService;
        }

        #endregion

        #region Public methods

        
        public void Dispose()
        {
            _missionGameService.OnCompleted -= OnMissionCompleted;
        }

        public void Initialize()
        {
            _missionGameService.OnCompleted += OnMissionCompleted;
        }
        
        public void SetCurrentHp(float hp)
        {
            _currentHp = hp;
            if (hp <= 0)
            {
                OnHpOver.Invoke();
            }
        }
        
        private void OnMissionCompleted()
        {
            _levelManagementService.IncrementLevel();

            if (_levelManagementService.IsCurrentLevelExists())
            {
                _stateMachine.Enter<GameState>();
            }
            else
            {
                _sceneLoadingService.LoadScene(Scene.Win);
            }
        }

        #endregion
    }
}