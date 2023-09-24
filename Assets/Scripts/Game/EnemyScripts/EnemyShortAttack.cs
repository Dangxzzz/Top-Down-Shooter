using TDS.Game.EnemyScripts.Base;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyShortAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyShortAttack))]
        [SerializeField] private int _damage = 1;
        [SerializeField] private Transform _hitTransform;
        [SerializeField] private float _hitRadius = 1f;
        [SerializeField] private LayerMask _hitMask;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            Animation.OnMeleeAttackHit += OnMeleeAttackHit;
        }

        private void OnDisable()
        {
            Animation.OnMeleeAttackHit -= OnMeleeAttackHit;
        }

        private void OnDrawGizmos()
        {
            if (_hitTransform == null)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_hitTransform.position, _hitRadius);
        }

        #endregion

        #region Private methods

        private void OnMeleeAttackHit()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_hitTransform.position, _hitRadius, _hitMask);
            foreach (Collider2D col in colliders)
            {
                if (col.TryGetComponent(out UnitHp hp))
                {
                    hp.Change(-_damage);
                }
            }
        }

        #endregion
    }
}