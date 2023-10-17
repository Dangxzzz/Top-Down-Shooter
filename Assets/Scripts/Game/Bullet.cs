using TDS.Utillity;
using UnityEngine;

namespace TDS.Game
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 3f;
        [SerializeField] private int _damage;

        private float _deathTime;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _rb.velocity = transform.up * _speed;
            this.StartTimer(_lifeTime, () => DestroyThis());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out UnitHp unitHp))
            {
                unitHp.Change(-_damage);
                DestroyThis();
            }
        }

        private void DestroyThis()
        {
            Lean.Pool.LeanPool.Despawn(this);
        }

        #endregion
    }
}