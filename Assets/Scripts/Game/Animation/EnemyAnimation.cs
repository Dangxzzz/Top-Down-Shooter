using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace TDS.Game.Animation
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Dead = Animator.StringToHash("Death");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int AttackIndex = Animator.StringToHash("AttackIndex");

        [SerializeField] private Animator _animator;

        #endregion

        #region Events

        public event Action OnMeleeAttackHit;

        #endregion

        #region Public methods

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDeath()
        {
            Debug.Log("Play Death");
            _animator.SetTrigger(Dead);
        }

        public void SetSpeed(float value)
        {
            _animator.SetFloat(Speed, value);
        }

        #endregion

        #region Private methods

        [Preserve]
        private void MeleeAttackHit()
        {
            Debug.Log("ShortAttack");
            OnMeleeAttackHit?.Invoke();
        }
        public void SetAttackIndex(int index)
        {
            _animator.SetFloat(AttackIndex, index);
        }

        #endregion
    }
}