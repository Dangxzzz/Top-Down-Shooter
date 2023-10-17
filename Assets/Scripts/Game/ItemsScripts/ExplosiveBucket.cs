using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.ItemsScripts
{
    public class ExplosiveBucket :Item
    {
         [SerializeField] private float _explosiveRadius;
         [SerializeField] private int _damage;
         [SerializeField] private GameObject _explosion;
         
         
         private void OnDrawGizmos()
         {
             if (transform.position == null)
             {
                 return;
             }

             Gizmos.color = Color.red;
             Gizmos.DrawWireSphere(transform.position, _explosiveRadius);
         }
         
        protected override void OnPerformAction(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.PlayerBullet))
            {
                Lean.Pool.LeanPool.Spawn(_explosion, transform.position, transform.rotation);
                base.OnPerformAction(other);
                Lean.Pool.LeanPool.Despawn(other.gameObject);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosiveRadius);

                foreach (Collider2D col in colliders)
                {
                    if (col.TryGetComponent(out UnitHp unitHp))
                    {
                        unitHp.Change(-_damage);
                    }
                }
            }
        }
    }
}
