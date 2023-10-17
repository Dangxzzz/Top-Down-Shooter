using TDS.Game.EnemyScripts.Base;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyIdleWithReturn : EnemyIdle
    {
        #region Variables

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private float _minDistance;
        

        private Transform _startPoint;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _startPoint = new GameObject($"{gameObject.name} start point").transform;
            _startPoint.position = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(_startPoint.position, transform.position) <= _minDistance)
            {
                _enemyMovement.SetTarget(null);
            }
        }

        private void OnEnable()
        {
            _enemyMovement.SetTarget(_startPoint);
        }

        #endregion
    }
}