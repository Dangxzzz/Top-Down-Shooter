using TDS.Utillity;
using UnityEngine;

namespace TDS.Infrastracture.Services.Missions.ReachDestination
{
    public class ReachDestinationMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;

        #endregion

        #region Properties

        public TriggerObserver TriggerObserver => _triggerObserver;

        #endregion
    }
}