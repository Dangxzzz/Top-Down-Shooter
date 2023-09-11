using UnityEngine;

namespace TDS.Game.Animation
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _animator;

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Dead = Animator.StringToHash("Death");

        #endregion

        #region Public methods

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Dead);
        }

        #endregion
    }
}