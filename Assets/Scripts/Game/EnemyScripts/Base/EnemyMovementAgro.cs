using Pathfinding;
using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.EnemyScripts.Base
{
    public class EnemyMovementAgro : EnemyComponents
    {
        #region Variables

        [SerializeField] private VisionArea _visionArea;
         [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private LayerMask _obstacleMask;

        private bool _isFollow;
        private Transform _player;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _visionArea.OnStay += OnObserverStay;
            _visionArea.OnExit += OnObserverExit;
        }

        private void OnDisable()
        {
            _visionArea.OnExit -= OnObserverExit;
            _visionArea.OnStay -= OnObserverStay;
        }
        
        #endregion

        #region Private methods

        private void OnObserverExit()
        {
            Debug.Log("Outside");
            _isFollow = false;
            SetTarget(null);
        }

        private void OnObserverStay(Collider2D other)
        {
            if (_isFollow)
            {
                return;
            }
            Vector3 direction = other.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, _obstacleMask);
            if (hit.transform != null)
            {
                return;
            }
            _isFollow = true;
            SetTarget(other.transform);
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