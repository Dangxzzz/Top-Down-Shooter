using UnityEngine;

namespace TDS.Game.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _animator;

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Dead = Animator.StringToHash("Death");
        private static readonly int Speed = Animator.StringToHash("Speed");

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

        public void SetSpeed(float value)
        {
            _animator.SetFloat(Speed, value);
        }

        #endregion
    }
}