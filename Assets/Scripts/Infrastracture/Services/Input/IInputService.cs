using System;
using TDS.Infrastracture.Locator;
using UnityEngine;

namespace TDS.Infrastracture.Services.Input
{
    public interface IInputService : IService
    {
        #region Events

        event Action OnAttack;

        #endregion

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