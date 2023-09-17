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
        private bool _needRotateToStart;
        private Vector3 _startPoint;

        #endregion

        private void Awake()
        {
            _startPoint = transform.position;
        }

        #region Unity lifecycle

        private void Update()
        {
            if (_target == null)
            {
                return;
            }
            Rotate();
        }

        private void Rotate()
        {
            Debug.Log($"Start pos {_startPoint}  CurrentPos {transform.position}");
            if (_needRotateToStart)
            {
                RotateToStartPoint();
            }
            else
            {
                RotateToTarget(_target);
            }
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
            _needRotateToStart = false;
        }

        private void OnObserverExit(Collider2D other)
        {
            _needRotateToStart = true;
        }

        private void RotateToTarget(Transform target)
        {
            Vector3 direction = transform.position - target.position;
            transform.up = direction;
        }

        private void RotateToStartPoint()
        {
            Debug.Log($"Rotate to start");
            if (transform.position!= _startPoint) 
            {
                Vector3 direction = transform.position-_startPoint;
                transform.up = direction;
            }
        }

        #endregion
    }
}