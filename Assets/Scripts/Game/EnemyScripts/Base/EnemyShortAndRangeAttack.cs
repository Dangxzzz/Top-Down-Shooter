using TDS.Game.EnemyScripts.Base;
using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyShortAndRangeAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyShortAndRangeAttack))]
        [SerializeField] private EnemyAttack _meleeAttack;
        [SerializeField] private EnemyAttack _rangeAttack;

        [Header("Observer")]
        [SerializeField] private TriggerObserver _meleeAttackTriggerObserver;

        private EnemyAttack _currentAttack;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            SetCurrentAttack(true);
        }

        private void OnEnable()
        {
            _meleeAttackTriggerObserver.OnEnter += OnMeleeAttackObserverEnter;
            _meleeAttackTriggerObserver.OnExit += OnMeleeAttackObserverExit;
        }

        private void OnDisable()
        {
            _meleeAttackTriggerObserver.OnEnter -= OnMeleeAttackObserverEnter;
            _meleeAttackTriggerObserver.OnExit -= OnMeleeAttackObserverExit;
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();

            _currentAttack.PerformAttackForced();
        }

        #endregion

        #region Private methods

        private void OnMeleeAttackObserverEnter(Collider2D obj)
        {
            SetCurrentAttack(false);
        }

        private void OnMeleeAttackObserverExit(Collider2D obj)
        {
            SetCurrentAttack(true);
        }

        private void SetCurrentAttack(bool isRange)
        {
            _currentAttack = isRange ? _rangeAttack : _meleeAttack;
            Animation.SetAttackIndex(isRange ? 0 : 1);
        }

        #endregion
    }
}