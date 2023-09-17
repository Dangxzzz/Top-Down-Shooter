using TDS.Game.Animation;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyDeathHappend : EnemyComponents
    {
        #region Variables

        [SerializeField] private EnemyComponents[] _enemyComponents;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyDeath _enemyDeath;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _enemyDeath.OnHappened += OnDead;
        }

        private void OnDisable()
        {
            _enemyDeath.OnHappened -= OnDead;
        }

        #endregion

        #region Private methods

        private void OnDead()
        {
            _attack.NeedStopAttack(true);
            _animation.PlayDeath();
            foreach (EnemyComponents component in _enemyComponents)
            {
                component.Deactivate();
            }
        }

        #endregion
    }
}