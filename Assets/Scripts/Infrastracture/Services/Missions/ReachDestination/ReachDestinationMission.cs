using UnityEngine;

namespace TDS.Infrastracture.Services.Missions.ReachDestination
{
    public sealed class ReachDestinationMission : BaseMission<ReachDestinationMissionCondition>
    {
        #region Protected methods

        protected override void OnDispose()
        {
            base.OnDispose();

            Condition.TriggerObserver.OnEnter -= OnTriggerEntered;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Condition.TriggerObserver.OnEnter += OnTriggerEntered;
        }

        #endregion

        #region Private methods

        private void OnTriggerEntered(Collider2D obj)
        {
            InvokeCompletion();
        }

        #endregion
    }
}