using TDS.Game.PlayerScripts;
using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.ItemsScripts
{
    public class Ammo : Item
    {
        #region Variables

        [SerializeField] private int  _ammo;
        
        #endregion

        #region Protected methods

        protected override void OnPerformAction(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.PlayerModelTag))
            {
                base.OnPerformAction(other);
                if (other.TryGetComponent(out PlayerAmmo ammo))
                {
                    ammo.Change(+_ammo);
                }
            }
        }

        #endregion
    }
}