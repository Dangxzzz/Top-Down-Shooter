using UnityEngine;

namespace TDS.Game.PlayerScripts
{
    public class PlayerComponents : MonoBehaviour
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
