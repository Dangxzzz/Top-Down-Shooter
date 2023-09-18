using System;
using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyMovementAgro : EnemyComponents
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyDirectMovement _directMovement;
        
     private Vector3 _startPosition;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _startPosition = transform.position;
        }

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
            Debug.Log("Go to player");
            _directMovement.NeedToStart=false;
            _directMovement.NeedToPatrole = false;
            SetTarget(other.transform);
        }

        private void OnObserverExit(Collider2D other)
        {
            _directMovement.NeedToStart=true;
        }

        private void SetTarget(Transform otherTransform)
        {
            if (_enemyMovement != null)
            {
                _enemyMovement.SetTarget(otherTransform);
            }
        }
        

        #endregion
    }
}
