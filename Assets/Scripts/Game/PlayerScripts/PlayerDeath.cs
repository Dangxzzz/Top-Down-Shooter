using System;
using UnityEngine;

namespace TDS.Game.PlayerScripts
{
    public class PlayerDeath : PlayerComponents
    {
        #region Variables

        [SerializeField] private UnitHp _hp;

        #endregion

        #region Events

        public event Action OnHappened;
        public event Action<float> OnHpChangedEvent;

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
                OnHpChangedEvent?.Invoke(_hp.Current);
                return;
            }

            IsDead = true;
            OnHappened?.Invoke();
        }

        #endregion
    }
}