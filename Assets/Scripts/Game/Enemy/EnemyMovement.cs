using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _player;

        #endregion

        #region Unity lifecycle

        private void Start() { }

        private void Update()
        {
            Transform playerPosition = _player.GetComponent<Transform>();
            Rotate(playerPosition);
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