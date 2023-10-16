using TDS.Infrastracture.Locator;
using Camera = UnityEngine.Camera;
using Transform = UnityEngine.Transform;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using UnityEngine;

namespace TDS.Infrastracture.Services.Input
{
    public interface IInputService : IService
    {
        #region Properties

        Vector2 Axes { get; }
        Vector3 LookDirection { get; }

        #endregion

        #region Public methods

        void Dispose();
        void Initialize(Camera camera, Transform playerMovementTransform);

        #endregion
    }
}
