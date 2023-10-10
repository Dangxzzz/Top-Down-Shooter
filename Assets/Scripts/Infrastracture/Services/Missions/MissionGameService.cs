using System;
using TDS.Infrastracture.Locator;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TDS.Infrastracture.Services.Missions
{
    public class MissionGameService : IService
    {
        #region Variables

        private readonly MissionFactory _factory = new();

        private BaseMission _currentMission;

        #endregion

        #region Events

        public event Action OnCompleted;

        #endregion

        #region Public methods

        public void Dispose()
        {
            Debug.LogError("MissionService Dispose");
            _currentMission.OnCompleted -= OnMissionCompleted;
            _currentMission.Dispose();
            _currentMission = null;
        }

        public void Initialize()
        {
            Debug.LogError("MissionService Initialize");

            MissionHolder holder = Object.FindObjectOfType<MissionHolder>();
            _currentMission = _factory.Create(holder.MissionCondition);
            _currentMission.OnCompleted += OnMissionCompleted;
            _currentMission.Initialize();
        }

        #endregion

        #region Private methods

        private void OnMissionCompleted()
        {
            Debug.LogError("Mission COMPLETED!");
            OnCompleted?.Invoke();
        }

        #endregion
    }
}