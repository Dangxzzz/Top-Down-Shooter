using TDS.Game.Animation;
using UnityEngine;
using UnityEngine.Serialization;

namespace TDS.Game.EnemyScripts.Base
{
    public abstract class EnemyMovement : EnemyComponents
    {
        #region Public methods
        [SerializeField] private EnemyAnimation _anim;

        #endregion

        #region Properties

        protected EnemyAnimation Anim => _anim;

        #endregion

        #region Public methods

        public abstract void SetTarget(Transform target);
        #endregion
    }
}
