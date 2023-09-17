using TDS.Utillity;
using UnityEngine;
using UnityEngine.Serialization;

namespace TDS.Game.EnemyScripts
{
    public class EnemyAttackAgro : EnemyComponents
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserverRangeAttack;
        [SerializeField] private TriggerObserver _triggerObserverShortAttack;
        [SerializeField] private EnemyAttack _attackRange;
        [SerializeField] private EnemyAttack _attackShort;
        [SerializeField] private EnemyMovement _movement;
        

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _triggerObserverShortAttack.OnEnter += ObserverShortAttackEnter;
            _triggerObserverShortAttack.OnExit += ObserverShortAttackExit;
            _triggerObserverRangeAttack.OnEnter += ObserverRangeAttackEnter;
            _triggerObserverRangeAttack.OnExit += ObserverRangeAttackExit;
        }

        private void OnDisable()
        {
            _triggerObserverShortAttack.OnEnter -= ObserverShortAttackEnter;
            _triggerObserverShortAttack.OnExit -= ObserverShortAttackExit;
            _triggerObserverRangeAttack.OnEnter -= ObserverRangeAttackEnter;
            _triggerObserverRangeAttack.OnExit -= ObserverRangeAttackExit;
        }

        #endregion

        #region Private methods

        private void ObserverRangeAttackEnter(Collider2D other)
        {
            SetActiveAttack(true,_attackRange);

            if (_movement != null)
            {
                _movement.Deactivate();
            }
        }

        private void ObserverShortAttackEnter(Collider2D other)
        {
            SetActiveAttack(true,_attackShort);

            if (_attackRange != null)
            {
                _attackRange.Deactivate();
            }
        }

        private void ObserverRangeAttackExit(Collider2D other)
        {
            SetActiveAttack(false,_attackRange);
            
            if (_movement != null)
            {
                _movement.Activate();
            }
        }
        
        private void ObserverShortAttackExit(Collider2D other)
        {
            SetActiveAttack(false,_attackShort);
            
            if (_attackRange != null)
            {
                _attackRange.Activate();
            }
        }

        private void SetActiveAttack(bool needAttack,EnemyAttack attack)
        {
            if (attack == null)
            {
                return;
            }

            if (needAttack)
            {
                attack.StartAttack();
            }
            else
            {
                attack.StopAttack();
            }
        }

        #endregion
    }
}
