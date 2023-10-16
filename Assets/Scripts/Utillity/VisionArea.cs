using System;
using System.Collections;
using UnityEngine;

namespace TDS.Utillity
{
    public class VisionArea : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _radius;
        [SerializeField] private float _minRadius;
        
        [Range(0, 360)]
        [SerializeField] private float _angle;
        [SerializeField] private LayerMask _targetMask;
        private bool _isInView;
        private bool _previouslyInView = false;
        private GameObject _playerRef;

        public event Action<Collider2D> OnStay;
        public event Action OnExit;
        
        #endregion

        #region Unity lifecycle

        public bool IsInView => _isInView;
        public float Radius => _radius;

        public float MinRadius => _minRadius;
        public GameObject PlayerRef => _playerRef;

        public float Angle => _angle;
        
        private void Start()
        {
            _playerRef = GameObject.FindGameObjectWithTag("PlayerModel");
            StartCoroutine(FOVRoutine());
        }
        
        private IEnumerator FOVRoutine()
        {
            WaitForSeconds wait = new WaitForSeconds(0.2f);

            while (true)
            {
                yield return wait;
                FieldOfViewCheck();
            }
        }
        #endregion

        #region Private methods

        private void FieldOfViewCheck()
        {
            Collider2D rangeChecks = Physics2D.OverlapCircle(transform.position, _radius, _targetMask);
            Collider2D minRangeCheck = Physics2D.OverlapCircle(transform.position, _minRadius, _targetMask);

            if (rangeChecks != null)
            {
                Transform target = rangeChecks.transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;
                if (Vector2.Angle(-transform.up, directionToTarget) < _angle / 2 || minRangeCheck!=null)
                {
                    CheckIsInView(rangeChecks);
                }
                else
                {
                    _isInView = false;
                    _previouslyInView = false;
                }
            }
            else
            {
                _isInView = false;
                if (_previouslyInView)
                {
                    OnExit?.Invoke();
                }

                _previouslyInView = false;
            }
        }

        private void CheckIsInView(Collider2D rangeChecks)
        {
            OnStay?.Invoke(rangeChecks);
            _isInView = true;
            if (!_previouslyInView)
            {
                OnExit?.Invoke();
            }

            _previouslyInView = true;
        }

        #endregion
    }
}