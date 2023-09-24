using TDS.Game.EnemyScripts.Base;
using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyRangeAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyRangeAttack))]
        [SerializeField] private Bullet _bulletPrefab;

        private Transform _playerTransform;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerTransform = GameObject.FindWithTag(Tags.PlayerModelTag).transform;
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();

            Instantiate(_bulletPrefab, transform.position, transform.rotation);
        }

        #endregion
    }
}