using TDS.Game.Animation;
using UnityEngine;

namespace TDS.Game.PlayerScripts
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Configs")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPositionTransform;
        [SerializeField] private Player _player;
        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (!_player.IsDead)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Fire();
                }
            }
        }

        #endregion

        #region Private methods

        private void CreateBullet()
        {
            Instantiate(_bulletPrefab,_bulletSpawnPositionTransform.position, transform.rotation);
        }

        private void Fire()
        {
            _animation.PlayAttack();
            CreateBullet();
        }

        #endregion
    }
}