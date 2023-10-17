using UnityEngine;

namespace TDS.Game.EnemyScripts.Base
{
    public class EnemyDeathHappend : EnemyComponents
    {
        #region Variables

        [SerializeField] private EnemyComponents[] _enemyComponents;
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

        private void OnDead(EnemyDeath enemyDeath)
        {
            
            foreach (EnemyComponents component in _enemyComponents)
            {
                component.Deactivate();
            }
            Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity=Vector2.zero;
            rigidbody2D.angularVelocity = 0;
        }
        

        #endregion
    }
}