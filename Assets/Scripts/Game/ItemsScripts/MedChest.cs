using UnityEngine;

namespace TDS.Game.ItemsScripts
{
    public class MedChest : Item
    {
        #region Variables

        [SerializeField] private UnitHp _playerHp;

        #endregion

        #region Protected methods

        protected override void OnPerformAction()
        {
            Debug.Log("Collision");
            _playerHp.Change(1);
        }

        #endregion
    }
}