using TDS.Utillity;
using UnityEngine;

namespace TDS.Game.ItemsScripts
{
    public class ExplosiveBucket :Item
    {
         [SerializeField] private float _explosiveRadius;
         [SerializeField] private int _damage;
         [SerializeField] private GameObject _explosion;
         
        protected override void OnPerformAction(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.PlayerBullet))
            {
                Instantiate(_explosion,transform.position, transform.rotation);
                base.OnPerformAction(other);
                Destroy(other.gameObject);
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
