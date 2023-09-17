using TDS.Game.Animation;
using TDS.Utillity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Game.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        #region Variables

        [Header("Configs")]
        [SerializeField] private int _hp;
        [SerializeField] private bool _isDead;
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private float _restartTime;
        [SerializeField] private int _maxHp;

        #endregion

        #region Properties

        public bool IsDead => _isDead;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.EnemyBulletTag))
            {
                ChangeHp(-1);
            }
            else if (other.gameObject.CompareTag(Tags.MedChestTag))
            {
                ChangeHp(1);
                Destroy(other.gameObject);
            }
        }

        #endregion

        #region Private methods

        private void ChangeHp(int health)
        {
            _hp += health;
            if (_hp <= 0)
            {
                _isDead = true;
                _animation.PlayDeath();
                this.StartTimer(_restartTime, () => RestartLevel());
            }
        }

        private void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}