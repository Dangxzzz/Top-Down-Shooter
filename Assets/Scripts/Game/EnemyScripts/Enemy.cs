using TDS.Game.Animation;
using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public abstract class Enemy : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _hp;
        [SerializeField] private bool _isDead;
        [SerializeField] private EnemyAnimation _animation;

        #endregion

        #region Properties

        public bool IsDead => _isDead;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.PlayerBullet)&& !_isDead)
            {
                ChangeHp();
            }
        }

        private void ChangeHp()
        {
            _hp--;
            if (_hp <= 0)
            {
                _isDead = true;
                _animation.PlayDeath();
            }
        }

        #endregion
    }
}