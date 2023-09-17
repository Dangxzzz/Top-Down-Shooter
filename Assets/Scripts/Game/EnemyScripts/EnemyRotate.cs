using System;
using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyRotate : EnemyComponents
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        private Transform _target;

        #endregion
        

        #region Unity lifecycle

        private void Update()
        {
            if (_target == null)
            {
                return;
            }
            RotateToTarget(_target);
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
            _target = other.transform;
        }

        private void OnObserverExit(Collider2D other)
        {
            _target = null;
        }

        private void RotateToTarget(Transform target)
        {
            Vector3 direction = transform.position - target.position;
            transform.up = direction;
        }

        #endregion
    }
}