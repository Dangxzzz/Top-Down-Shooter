using System;
using TMPro;
using UnityEngine;

namespace TDS.Utillity
{
    public class BossSpawner : MonoBehaviour
    {
        [SerializeField] private LevelService _levelService;
        [SerializeField] private GameObject _bossPrefab;
        [SerializeField] private Transform _bossSpawnPlace;
        
        private void Start()
        {
            _levelService.OnAllEnemyDead += SpawnBoss;
        }

        private void OnDisable()
        {
            _levelService.OnAllEnemyDead -= SpawnBoss;
        }

        private void SpawnBoss()
        {
            Instantiate(_bossPrefab, _bossSpawnPlace.position, Quaternion.identity);
        }
    }
}
