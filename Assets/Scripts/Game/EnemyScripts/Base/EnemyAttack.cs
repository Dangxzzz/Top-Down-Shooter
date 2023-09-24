using TDS.Game.Animation;
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

        #endregion

        #region Properties

        protected EnemyAnimation Animation => _anim;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (!_needAttack)
            {
                return;
            }

            if (Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + _attackDelay;
                OnPerformAttack();
            }
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