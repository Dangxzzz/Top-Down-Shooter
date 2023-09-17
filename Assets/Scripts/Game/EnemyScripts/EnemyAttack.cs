using System.Collections;
using TDS.Game.Animation;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public abstract class EnemyAttack : EnemyComponents
    {
        #region Variables

        [Header(nameof(EnemyAttack))]
        [SerializeField] private float _attackDelay = 1f;

        private IEnumerator _attackRoutine;
        private WaitForSeconds _wait;
        private bool _needStopAttack;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _wait = new WaitForSeconds(_attackDelay);
        }

        private void OnDisable()
        {
            StopAttack();
        }

        #endregion

        #region Public methods

        public void StartAttack()
        {
            _attackRoutine = StartAttackInternal();
            StartCoroutine(_attackRoutine);
        }

        public void NeedStopAttack(bool needStopAttack)
        {
            _needStopAttack = needStopAttack;
        }

        public void StopAttack()
        {
            if (_attackRoutine != null)
            {
                StopCoroutine(_attackRoutine);
                _attackRoutine = null;
            }
        }

        #endregion

        #region Protected methods

        protected virtual void OnPerformAttack() { }

        #endregion

        #region Private methods

        private IEnumerator StartAttackInternal()
        {
            yield return _wait;
            while (!_needStopAttack)
            {
                OnPerformAttack();
                yield return _wait;
            }
        }

        #endregion
    }
}
