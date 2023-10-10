// using SPL.Editor;
// using TDS.Infrastracture.Services;
// using TDS.Infrastracture.Services.SceneLoadingService;
// using TDS.Utillity;
// using Unity.VisualScripting;
// using UnityEngine;
// using Scene = TDS.Infrastracture.Services.SceneLoadingService.Scene;
//
// namespace TDS.Infrastracture.StateMachine
// {
//     public class GameState : AppState
//     {
//         #region Setup/Teardown
//
//         public GameState(ServiceLocator serviceLocator) : base(serviceLocator) { }
//
//         #endregion
//
//         #region Public methods
//
//         public override void Enter()
//         {
//             Debug.LogError($"GameState Enter '{Time.frameCount}'");
//
//             ServiceLocator.Get<SceneLoadingService>().LoadScene(Scene.Game);
//
//             ServiceLocator.Get<CoroutineRunner>().StartFrameTimer(1, InitAfterLoadScene);
//         }
//
//         public override void Exit()
//         {
//             Debug.LogError("GameState Exit");
//             ServiceLocator.Get<MissionGameService>().Dispose();
//         }
//
//         #endregion
//
//         #region Private methods
//
//         private void InitAfterLoadScene()
//         {
//             Debug.LogError($"GameState InitAfterLoadScene '{Time.frameCount}'");
//             // ServiceLocator.Get<MissionGameService>().Initialize();
//         }
//
//         #endregion
//     }
// }