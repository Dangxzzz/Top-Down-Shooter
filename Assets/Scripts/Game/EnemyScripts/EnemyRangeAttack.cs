using TDS.Game.EnemyScripts.Base;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyRangeAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyRangeAttack))]
        [SerializeField] private Bullet _bulletPrefab;
        
        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();
            Lean.Pool.LeanPool.Spawn(_bulletPrefab, transform.position, transform.rotation);
        }

        #endregion
    }
}