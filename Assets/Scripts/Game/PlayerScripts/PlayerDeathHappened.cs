using TDS.Game.Animation;
using UnityEngine;

namespace TDS.Game.PlayerScripts
{
    public class PlayerDeathHappened : PlayerComponents
    {
        #region Variables

        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private PlayerDeath _playerDeath;
        
        [SerializeField] private PlayerComponents[] _playerComponents;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _playerDeath.OnHappened += OnDead;
        }

        private void OnDisable()
        {
            _playerDeath.OnHappened -= OnDead;
        }

        #endregion

        #region Private methods

        private void OnDead()
        {
            _animation.PlayDeath();
            foreach (PlayerComponents component in _playerComponents)
            {
                component.Deactivate();
            }
        }

        #endregion
    }
}