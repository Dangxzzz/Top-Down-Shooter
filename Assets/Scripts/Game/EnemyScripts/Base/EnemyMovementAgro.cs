
using TDS.Utility;
using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.EnemyScripts.Base
{
    public class EnemyMovementAgro : EnemyComponents
    {
        #region Variables

        [SerializeField] private RayCastObserver _raycastObserver;
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyIdle _idle;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _raycastObserver.OnEnterRayCast += OnObserverEnter;
            _raycastObserver.OnExitRayCast += OnObserverEnter;
            _triggerObserver.OnEnter += OnObserverEnter;
            _triggerObserver.OnExit += OnObserverExit;
        }

        private void OnDisable()
        {
            _raycastObserver.OnEnterRayCast -= OnObserverEnter;
            _triggerObserver.OnEnter -= OnObserverEnter;
            _triggerObserver.OnExit -= OnObserverExit;
            _raycastObserver.OnExitRayCast -= OnObserverEnter;
        }

        #endregion

        #region Private methods

        private void OnObserverEnter(Collider2D other)
        {
            if (other.transform == null)
            {
                return;
            }

            Debug.Log(other);
            SetTarget(other.transform);
        }
        
        private void OnObserverExit(Collider2D other)
        {
            SetTarget(null);
        }

        private void SetTarget(Transform otherTransform)
        {
            if (_enemyMovement != null)
            {
                _enemyMovement.SetTarget(otherTransform);
            }

            if (_idle != null)
            {
                if (otherTransform == null)
                {
                    _idle.Activate();
                }
                else
                {
                    _idle.Deactivate();
                }
            }
        }

        #endregion
    }
}