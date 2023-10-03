
using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.EnemyScripts.Base
{
    public class EnemyAttackAgro : EnemyComponents
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyMovement _movement;
        

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _triggerObserver.OnEnter += OnObserverEnter;
            _triggerObserver.OnExit += OnObserverExit;
        }

        private void OnDisable()
        {
            _triggerObserver.OnEnter -= OnObserverEnter;
            _triggerObserver.OnExit -= OnObserverExit;
        }

        #endregion

        #region Private methods

        private void OnObserverEnter(Collider2D other)
        {
            SetActiveAttack(true);

            if (_movement != null)
            {
                _movement.Deactivate();
            }
        }

        private void OnObserverExit(Collider2D other)
        {
            SetActiveAttack(false);
            
            if (_movement != null)
            {
                _movement.Activate();
            }
        }

        private void SetActiveAttack(bool needAttack)
        {
            if (_attack == null)
            {
                return;
            }

            if (needAttack)
            {
                _attack.StartAttack();
            }
            else
            {
                _attack.StopAttack();
            }
        }

        #endregion
    }


}