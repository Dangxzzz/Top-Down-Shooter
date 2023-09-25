using System;
using System.Collections.Generic;
using TDS.Game.EnemyScripts;
using TDS.Game.EnemyScripts.Base;
using UnityEngine;

namespace TDS.Utillity
{
    public class LevelService : MonoBehaviour
    {

        private List<EnemyDeath> _enemyDeaths = new List<EnemyDeath>();
        [SerializeField] private GameObject _bossFightLabel;
        

        public event Action OnAllEnemyDead;
        private void Start()
        {
            EnemyDeath.OnCreated += AddEnemy;
            EnemyDeath.OnDead += RemoveEnemy;
        }
        

        private void OnDisable()
        {
            EnemyDeath.OnCreated -= AddEnemy;
            EnemyDeath.OnDead -= RemoveEnemy;
        }

        private void AddEnemy(EnemyDeath enemyDeath)
        { 
            _enemyDeaths.Add(enemyDeath);
            Debug.Log($" Enemies {_enemyDeaths.Count}");
        }

        private void RemoveEnemy(EnemyDeath enemyDeath)
        {
            _enemyDeaths.Remove(enemyDeath);
            if (_enemyDeaths.Count == 0)
            {
                _bossFightLabel.SetActive(true);
                _bossFightLabel.GetComponent<BossFightLabelSpawner>().IsActive = true;
                OnAllEnemyDead?.Invoke();
            }
        }
    }
}
