using System.Collections;
using TDS.Game.Animation;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [Header("Configs")]
        [SerializeField] private float _fireSpeed;
        [SerializeField] private GameObject _enemyBulletPrefab;
        [SerializeField] private EnemyAnimation _animation;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            StartCoroutine(EnemyFire());
        }

        #endregion

        #region Private methods

        private void CreateBullet()
        {
            Instantiate(_enemyBulletPrefab, transform.position, transform.rotation);
        }

        private IEnumerator EnemyFire()
        {
            while (true)
            {
                _animation.PlayAttack();
                CreateBullet();
                yield return new WaitForSeconds(_fireSpeed); 
            }
        }

        #endregion
    }
}