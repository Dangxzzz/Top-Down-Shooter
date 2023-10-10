using TDS.Game.EnemyScripts.Base;
using UnityEngine;

namespace TDS.Infrastracture.Services.Missions.KillSpecificEnemy
{
    public class KillSpecificEnemyMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private EnemyDeath _enemyDeath;

        #endregion

        #region Properties

        public EnemyDeath EnemyDeath => _enemyDeath;

        #endregion
    }
}