using UnityEngine;

namespace TDS.Game.ItemsScripts
{
    public abstract class Item : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnPerformAction(other);
        }

        #endregion

        #region Protected methods

        protected virtual void OnPerformAction(Collider2D other)
        {
            Destroy(gameObject);
        }

        #endregion
    }
}