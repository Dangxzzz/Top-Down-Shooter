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
        [SerializeField] private bool _isFinalBoss;

        #endregion

        #region Events

        public static event Action<EnemyDeath> OnCreated;
        public static event Action<EnemyDeath> OnDead;

        public event Action OnHappened;

        #endregion

        #region Properties

        public bool IsDead { get; private set; }

        public bool IsFinalBoss => _isFinalBoss;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

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
            OnHappened?.Invoke();
            OnDead?.Invoke(this);

        }

        #endregion
    }
}