using TDS.Game.PlayerScripts;
using UnityEngine;

namespace TDS.Infrastracture.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        #region Variables

        private Camera _camera;
        private Transform _playerMovementTransform;

        #endregion

        #region Properties

        public Vector2 Axes => new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        public Vector3 LookDirection => GetLookDirection();

        #endregion

        #region IInputService

        public void Dispose()
        {
            _camera = null;
            _playerMovementTransform = null;
            Debug.Log("Exit input");
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
            if (_camera==null || _playerMovementTransform==null)
            {
                _playerMovementTransform = Object.FindObjectOfType<PlayerMovement>().transform;
                _camera = Camera.main;
            }
            _playerMovementTransform = Object.FindObjectOfType<PlayerMovement>().transform;
            Vector3 worldMousePosition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            worldMousePosition.z = 0;
            return worldMousePosition-_playerMovementTransform.position;
        }

        #endregion
    }
}