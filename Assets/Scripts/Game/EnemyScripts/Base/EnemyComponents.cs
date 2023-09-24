using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public abstract class EnemyComponents : MonoBehaviour
    {
        #region Public methods

        public void Activate()
        {
            enabled = true;
        }

        public void Deactivate()
        {
            enabled = false;
        }

        #endregion
    }
}
