using TDS.Utillity;
using UnityEngine;
using UnityEngine.Serialization;

namespace TDS.Game.EnemyScripts.Base
{
    public class EnemyRotate : EnemyComponents
    {
        #region Variables

        [SerializeField] private VisionArea _visionArea;
        [SerializeField] private LayerMask _obstacleMask;
        
        private bool _isPatroleMode;
        private Transform _target;
        private bool _isFollow;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_target == null)
            {
                return;
            }
            Rotate();
        }

        private void OnEnable()
        {
            _visionArea.OnStay += OnObserverStay;
            _visionArea.OnExit += OnObserverExit;
        }

        private void OnDisable()
        {
            _visionArea.OnStay -= OnObserverStay;
            _visionArea.OnExit -= OnObserverExit;
        }

        #endregion

        #region Private methods

        private void OnObserverStay(Collider2D other)
        {
            if (_isFollow)
            { //TODO: DANYA REMOVE THIS!!!!!!!!!!!!!!!!!!!!!!!
                return;
            }
            Vector3 direction = other.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, _obstacleMask);
            if (hit.transform != null)
            {
                return;
            }
            _isFollow = true;
            _target = other.transform;
        }

        private void OnObserverExit()
        {
            _target = null;
        }

        private void Rotate()
        {
            if (_isPatroleMode)
            {
                return;
            }
            else
            {
                RotateToTarget(_target);
            }
        }

        private void RotateToTarget(Transform target)
        {
            Vector3 direction = transform.position - target.position;
            transform.up = direction;
        }

        #endregion
    }
}