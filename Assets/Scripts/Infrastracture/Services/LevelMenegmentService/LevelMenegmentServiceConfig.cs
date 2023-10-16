using UnityEngine;

namespace TDS.Infrastracture.Services.LevelMenegmentService
{
    [CreateAssetMenu(fileName = nameof(LevelManagementServiceConfig), menuName = "TDS/Game/Level Management Config")]
    public class LevelManagementServiceConfig : ScriptableObject
    {
        #region Variables

        [SerializeField] private string[] _sceneNames;

        #endregion

        #region Properties

        public string[] SceneNames => _sceneNames;

        #endregion
    }
}