using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.ItemsScripts
{
    public class MedChest : Item
    {
        #region Variables

        [SerializeField] private int  _heal;
        
        #endregion

        #region Protected methods

        protected override void OnPerformAction(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.PlayerModelTag))
            {
                base.OnPerformAction(other);
                if (other.TryGetComponent(out UnitHp unitHp))
                {
                    unitHp.Change(+_heal);
                }
            }
        }

        #endregion
    }
}