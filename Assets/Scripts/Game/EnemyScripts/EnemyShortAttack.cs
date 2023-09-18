using TDS.Game.Animation;
using UnityEngine;

namespace TDS.Game.EnemyScripts
{
    
    public class EnemyShortAttack : EnemyAttack
    {
        [SerializeField] private int _damage;
        [SerializeField] private UnitHp _hp;
        [SerializeField] private EnemyAnimation _animation;
        
        protected override void OnPerformAttack()
        {
            Debug.Log("Attack");
            base.OnPerformAttack();
            _hp.Change(-_damage);
            _animation.PlayShortAttack();
        }
    }
}
