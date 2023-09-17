using UnityEngine;

namespace TDS.Game.ItemsScripts
{
    public abstract class Item : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnPerformAction();
            Destroy(gameObject);
        }

        #endregion

        #region Protected methods

        protected abstract void OnPerformAction();

        #endregion
    }
}