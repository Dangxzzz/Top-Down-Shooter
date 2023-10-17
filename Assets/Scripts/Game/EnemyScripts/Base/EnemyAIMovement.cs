using System;
using Pathfinding;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TDS.Game.EnemyScripts.Base
{
    public class EnemyAIMovement : EnemyMovement
    {
        [SerializeField] private AIDestinationSetter _targetSetter;
        [SerializeField] private AIPath _aiPath;
        public override void SetTarget(Transform targetPlayer)
        {
            _targetSetter.target = targetPlayer;
            if (_targetSetter.target==null)
            {
                 Anim.SetSpeed(0);
            }
            else
            {
                Anim.SetSpeed(1);
            }
        }

        private void OnDisable()
        {
            _aiPath.enabled = false;
        }

        private void OnEnable()
        {
            _aiPath.enabled = true;
        }
    }
}