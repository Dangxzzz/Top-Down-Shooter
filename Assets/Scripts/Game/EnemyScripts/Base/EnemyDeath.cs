using System;
using TDS.Game.Animation;
using UnityEngine;

namespace TDS.Game.EnemyScripts.Base
{
    public class EnemyDeath : EnemyComponents
    {
        #region Variables

        [SerializeField] private UnitHp _hp;
        [SerializeField] private EnemyAnimation _anim;

        #endregion

        #region Events
        
        public event Action<EnemyDeath> OnHappened;

        #endregion

        #region Properties

        public bool IsDead { get; private set; }
        

        #endregion

        #region Unity lifecycle
        
        private void OnEnable()
        {
            OnHpChanged(_hp.Current);
            _hp.OnChanged += OnHpChanged;
        }

        private void OnDisable()
        {
            _hp.OnChanged -= OnHpChanged;
        }

        #endregion

        #region Private methods

        private void OnHpChanged(int currentHp)
        {
            if (IsDead || currentHp > 0)
            {
                return;
            }

            IsDead = true;
            _anim.PlayDeath();
            gameObject.GetComponent<Collider2D>().enabled = false;
            OnHappened?.Invoke(this);
        }

        #endregion
    }
}