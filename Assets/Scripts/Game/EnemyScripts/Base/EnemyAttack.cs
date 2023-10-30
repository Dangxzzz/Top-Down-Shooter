using System;
using TDS.Game.Animation;
using TDS.Game.PlayerScripts;
using UnityEngine;

namespace TDS.Game.EnemyScripts.Base
{
    public abstract class EnemyAttack : EnemyComponents
    {
        #region Variables

        [Header(nameof(EnemyAttack))]
        [SerializeField] private float _attackDelay = 1f;
       [SerializeField] private EnemyAnimation _anim;

        private bool _needAttack;
        private float _nextAttackTime;
        private Transform _playerTransform;

        #endregion

        #region Properties

        protected EnemyAnimation Animation => _anim;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        }

        private void Update()
        {
            if (!_needAttack)
            {
                return;
            }
            RotateToPlayer();
            if (Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + _attackDelay;
                OnPerformAttack();
            }
        }

        private void RotateToPlayer()
        {
            Vector3 direction = _playerTransform.position - transform.position;
            transform.up = direction;
        }

        #endregion

        #region Public methods

        public void StartAttack()
        {
            _needAttack = true;
        }

        public void StopAttack()
        {
            _needAttack = false;
        }

        #endregion

        #region Protected methods

        protected virtual void OnPerformAttack()
        {
            _anim.PlayAttack();
        }

        #endregion
    }
}