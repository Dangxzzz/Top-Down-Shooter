using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    public class EnemyMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Enemy _enemy;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            
        }

        private void Update()
        {
            if (!_enemy.IsDead)
            {
                Rotate(_playerTransform);
            }
        }

        #endregion

        #region Private methods

        private void Rotate(Transform playerPosition)
        {
            Vector3 direction =transform.position- playerPosition.position;
            transform.up = direction;
        }

        #endregion
    }
}