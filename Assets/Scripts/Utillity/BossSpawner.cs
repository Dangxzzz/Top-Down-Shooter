// using UnityEngine;
//
// namespace TDS.Utillity
// {
//     public class BossSpawner : MonoBehaviour
//     {
//         #region Variables
//
//         // [SerializeField] private LevelService _levelService;
//         [SerializeField] private GameObject _bossPrefab;
//         [SerializeField] private Transform _bossSpawnPlace;
//         [SerializeField] private GameObject _bossFightLabel;
//
//         #endregion
//
//         #region Unity lifecycle
//
//         private void Start()
//         {
//             _levelService.OnAllEnemyDead += SpawnBoss;
//         }
//
//         private void OnDisable()
//         {
//             _levelService.OnAllEnemyDead -= SpawnBoss;
//         }
//
//         #endregion
//
//         #region Private methods
//
//         private void SpawnBoss()
//         {
//             _bossFightLabel.SetActive(true);
//             _bossFightLabel.GetComponent<BossFightLabelSpawner>().IsActive = true;
//             Instantiate(_bossPrefab, _bossSpawnPlace.position, Quaternion.identity);
//         }
//
//         #endregion
//     }
// }