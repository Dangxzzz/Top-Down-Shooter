using TDS.Game.Animation;
using TDS.Infrastracture.Services.Input;
using UnityEngine;

namespace TDS.Game.PlayerScripts
{
    public class PlayerAttack : PlayerComponents
    {
        #region Variables

        [Header("Configs")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPositionTransform;
        [SerializeField] private PlayerAmmo _playerAmmo;

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        private IInputService _inputService;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            if (_inputService != null)
            {
                _inputService.OnAttack += Fire;
            }
        }

        private void OnDisable()
        {
            _inputService.OnAttack -= Fire;
        }

        #endregion

        #region Public methods

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnAttack += Fire;
        }

        #endregion

        #region Private methods

        private void CreateBullet()
        {
            _playerAmmo.Change(-1);
            if (_playerAmmo.Current <= 0)
            {
                return;
            }

            Lean.Pool.LeanPool.Spawn(_bulletPrefab, _bulletSpawnPositionTransform.position, transform.rotation);
        }

        private void Fire()
        {
            _animation.PlayAttack();
            CreateBullet();
        }

        #endregion
    }
}