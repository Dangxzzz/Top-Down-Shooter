using System;
using System.Collections.Generic;
using TDS.Game.EnemyScripts.Base;
using TDS.Game.PlayerScripts;
using TDS.UI;
using UnityEngine;

namespace TDS.Utillity
{
    public class LevelService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerDeath _playerDeath;
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private HpBar _hpBar;
        

        private readonly List<EnemyDeath> _enemies = new();

        #endregion

        #region Events

        public event Action OnAllEnemyDead;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            EnemyDeath.OnCreated += AddEnemy;
            EnemyDeath.OnDead += RemoveEnemy;
            _playerDeath.OnHappened += RestartScene;
            _playerDeath.OnHpChangedEvent += ChangeBar;
        }

        private void OnDisable()
        {
            EnemyDeath.OnCreated -= AddEnemy;
            EnemyDeath.OnDead -= RemoveEnemy;
            _playerDeath.OnHappened -= RestartScene;
            _playerDeath.OnHpChangedEvent -= ChangeBar;
        }

        #endregion

        #region Private methods

        private void ChangeBar(float currentHp)
        {
            Debug.Log($"CurrentHP {currentHp}");
            _hpBar.ChangeBar(currentHp);
        }
        private void AddEnemy(EnemyDeath enemyDeath)
        {
            _enemies.Add(enemyDeath);
        }

        private void LoadNextlevelTimer()
        {
            _sceneLoader.LoadNextlevelTimer();
        }

        private void RemoveEnemy(EnemyDeath enemyDeath)
        {
            if (enemyDeath.IsFinalBoss)
            {
                LoadNextlevelTimer();
            }
            else
            {
                _enemies.Remove(enemyDeath);
            }
            if (_enemies.Count == 0)
            {
                OnAllEnemyDead?.Invoke();
            }
        }

        private void RestartScene()
        {
            _sceneLoader.RestartScene();
        }

        #endregion
    }
}