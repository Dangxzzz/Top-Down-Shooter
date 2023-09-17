using TDS.Game.Animation;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyRangeAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyRangeAttack))]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private EnemyAnimation _animation;

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();

            Instantiate(_bulletPrefab, transform.position, transform.rotation);
            _animation.PlayAttack();
        }

        #endregion
    }
}