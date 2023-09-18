using System;
using TDS.Game.Animation;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyDirectMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private Vector3[] points;
        [SerializeField] private EnemyAnimation _animation;
        private bool _needToStart;
        private Vector3 _startPoint;
        private bool _isPatrolMode;
        private int _currentPatrolIndex;

        private Transform _target;

        #endregion

        #region Properties

        public bool NeedToStart
        {
            get => _needToStart;
            set => _needToStart = value;
        }
        
        public bool NeedToPatrole
        {
            get => _isPatrolMode;
            set => _isPatrolMode = value;
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
            _animation.SetSpeed(_rb.velocity.magnitude);
            if (_needToStart)
            {
                Debug.Log("Move to start");
                MoveToStartPoint(_startPoint);
            }

            else if (_isPatrolMode)
            {
                Patrole();
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
            if (Vector3.Distance(transform.position, startPoint) > 0.3f)
            {
                Debug.Log("StartPoint go");
                Vector3 direction = (startPoint - transform.position).normalized;
                transform.up = -direction;
                _rb.velocity = direction * +_speed;
            }
            else
            {
                _isPatrolMode = true;
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
            Debug.Log($"Move");
            Vector3 direction = (_target.position - transform.position).normalized;
            _rb.velocity = direction * +_speed;
        }

        private void Patrole()
        {
            if (points.Length == 0)
            {
                return;
            }
            
            Vector3 currentPatrolPoint = points[_currentPatrolIndex];
            
            Vector3 direction = (currentPatrolPoint - transform.position).normalized;
            transform.up = -direction;
            
            _rb.velocity = direction * _speed;
            
            
            if (Vector3.Distance(transform.position, currentPatrolPoint) < 0.1f)
            {
                _currentPatrolIndex++;
                
                if (_currentPatrolIndex >= points.Length)
                {
                    _currentPatrolIndex = 0;
                }
            }
        }

        #endregion
    }
}