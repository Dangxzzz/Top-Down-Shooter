using System;
using TDS.Game.ItemsScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDS.Game.EnemyScripts.Base
{
    public class EnemyDrop : EnemyComponents
    {
        #region Variables

        [SerializeField] private ItemSpawnData[] _items;
        [SerializeField] private int _dropChance;
        [SerializeField] private EnemyDeath _enemyDeath;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            if (_enemyDeath != null)
            {
                _enemyDeath.OnHappened += DropItem;
            }
        }

        private void OnDisable()
        {
            if (_enemyDeath != null)
            {
                _enemyDeath.OnHappened -= DropItem;
            }
        }

        private void OnValidate()
        {
            if (_items == null)
            {
                return;
            }

            foreach (ItemSpawnData spawnData in _items)
            {
                spawnData.OnValidate();
            }
        }

        #endregion

        #region Private methods

        private void DropItem()
        {
            if (_items == null || _items.Length == 0)
            {
                return;
            }

            int chance = Random.Range(0, 101);
            if (_dropChance >= chance)
            {
                InstantiateItemPrebab(transform.position);
            }
        }

        private void InstantiateItemPrebab(Vector2 position)
        {
            int weightSum = 0;
            foreach (ItemSpawnData spawnData in _items)
            {
                weightSum += spawnData.SpawnWeight;
            }

            int randomWeight = Random.Range(0, weightSum + 1);
            int selectedWeight = 0;

            for (int i = 0; i < _items.Length; i++)
            {
                ItemSpawnData spawnData = _items[i];
                selectedWeight += spawnData.SpawnWeight;

                if (selectedWeight >= randomWeight)
                {
                    Instantiate(spawnData.ItemPrefab, position, Quaternion.identity);

                    return;
                }
            }
        }

        #endregion

        #region Local data

        [Serializable]
        private class ItemSpawnData
        {
            #region Variables
            
            [HideInInspector]
            public string Name;
            public Item ItemPrefab;
            public int SpawnWeight;

            #endregion

            #region Public methods

            public void OnValidate()
            {
                if (ItemPrefab == null)
                {
                    Name = "Empty";
                }
                else
                {
                    Name = $"{ItemPrefab.name}:{SpawnWeight}";
                }
            }

            #endregion
        }

        #endregion
    }
}