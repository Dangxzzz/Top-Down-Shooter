using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.ItemsScripts
{
    public class MedChest : Item
    {
        #region Variables

        [SerializeField] private UnitHp _playerHp;

        #endregion

        #region Protected methods

        protected override void OnPerformAction(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.PlayerModelTag))
            {
                base.OnPerformAction(other);
                Debug.Log("Collsion");
                _playerHp.Change(1);
            }
        }

        #endregion
    }
}