using TDS.Game.EnemyScripts.Base;

namespace TDS.Infrastracture.Services.Missions.KillSpecificEnemy
{
    public sealed class KillSpecificEnemyMission : BaseMission<KillSpecificEnemyMissionCondition>
    {
        #region Protected methods

        protected override void OnDispose()
        {
            base.OnDispose();

            Condition.EnemyDeath.OnHappened -= OnEnemyDead;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Condition.EnemyDeath.OnHappened += OnEnemyDead;
        }

        #endregion

        #region Private methods

        private void OnEnemyDead(EnemyDeath enemyDeath)
        {
            InvokeCompletion();
        }

        #endregion
    }
}