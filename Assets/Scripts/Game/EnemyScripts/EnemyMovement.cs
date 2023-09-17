using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public abstract class EnemyMovement : EnemyComponents
    {
        #region Public methods

        public abstract void SetTarget(Transform target);

        #endregion
    }
}
