using System;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyDirectMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;
        private bool _needToStart;
        private Vector3 _startPoint;

        private Transform _target;

        #endregion

        #region Properties

        public bool NeedToStart
        {
            get => _needToStart;
            set => _needToStart = value;
        }
        
        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            if (_needToStart)
            {
                MoveToStartPoint(_startPoint);
            }
            else
            {
                MoveToTarget();
            }
        }

        private void OnDisable()
        {
            _rb.velocity = Vector2.zero;
        }

        #endregion

        #region Public methods

        public void MoveToStartPoint(Vector3 startPoint)
        {
            if (transform.position!=startPoint)
            {
                Vector3 direction = (startPoint - transform.position).normalized;
                _rb.velocity = direction * +_speed;
            }
            else
            {
                _needToStart = false;
            }
        }

        public override void SetTarget(Transform target)
        {
            _target = target;

            if (_target == null)
            {
                _rb.velocity = Vector2.zero;
            }
        }

        #endregion

        #region Private methods

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _rb.velocity = direction * +_speed;
        }

        #endregion
    }
}