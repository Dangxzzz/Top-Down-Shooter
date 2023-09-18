using UnityEngine;

namespace TDS.Game.Animation
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _animator;

        private static readonly int ShortAttack = Animator.StringToHash("ShortAttack");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Dead = Animator.StringToHash("Death");
        private static readonly int Walk = Animator.StringToHash("Speed");

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

        public void PlayShortAttack()
        {
            _animator.SetTrigger(ShortAttack);
        }
        public void SetSpeed(float value)
        {
            _animator.SetFloat(Walk, value);
        }

        #endregion
    }
}