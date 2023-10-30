using System;
using UnityEngine;

namespace TDS.Infrastracture.Services.Input
{
    public class StandaloneInputService : MonoBehaviour, IInputService
    {
        #region Variables

        private Camera _camera;
        private Transform _playerMovementTransform;

        #endregion

        #region Events

        public event Action OnAttack;

        #endregion

        #region Properties

        public Vector2 Axes => new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        public Vector3 LookDirection => GetLookDirection();

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                OnAttack?.Invoke();
            }
        }

        #endregion

        #region IInputService

        public void Dispose()
        {
            _camera = null;
            _playerMovementTransform = null;
        }

        public void Initialize(Camera camera, Transform playerMovementTransform)
        {
            _camera = camera;
            _playerMovementTransform = playerMovementTransform;
        }

        #endregion

        #region Private methods

        private Vector3 GetLookDirection()
        {
            Vector3 worldMousePosition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            worldMousePosition.z = 0;
            return worldMousePosition - _playerMovementTransform.position;
        }

        #endregion
    }
}