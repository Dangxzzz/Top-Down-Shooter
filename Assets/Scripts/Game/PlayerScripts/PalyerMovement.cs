// using TDS.Game.Animation;
// using UnityEngine;
//
// namespace TDS.Game.PlayerScripts
// {
//     public class PalyerMovement : PlayerComponents
//     {
//         #region Variables
//
//         [Header("Components")]
//         [SerializeField] private PlayerAnimation _animation;
//
//         [Header("Settings")]
//         [SerializeField] private float _speed = 5f;
//
//         #endregion
//
//         #region Unity lifecycle
//
//         private void Update()
//         {
//             Rotate();
//             Move();
//         }
//
//         #endregion
//
//         #region Private methods
//
//         private void Move()
//         {
//             Vector2 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
//             Vector2 velocity = input * _speed;
//
//             Vector3 currentPosition = transform.position;
//             currentPosition.x += velocity.x * Time.deltaTime;
//             currentPosition.y += velocity.y * Time.deltaTime;
//             transform.position = currentPosition;
//
//             _animation.SetSpeed(velocity.magnitude);
//         }
//
//         private void Rotate()
//         {
//             Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             worldMousePosition.z = 0;
//             Vector3 direction = transform.position - worldMousePosition;
//             transform.up = direction;
//         }
//
//         #endregion
//     }
// }

using TDS.Game.Animation;
using TDS.Infrastracture.Services.Input;
using UnityEngine;

namespace TDS.Game.PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private Rigidbody2D _rb;

        [Header("Settings")]
        [SerializeField] private float _speed = 5f;

        private IInputService _inputService;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_inputService == null)
            {
                return;
            }

            Rotate();
            Move();
        }

        #endregion

        #region Public methods

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Dispose()
        {
            _inputService = null;
        }

        #endregion

        #region Private methods

        private void Move()
        {
            Vector2 velocity = _inputService.Axes * _speed;

            _rb.velocity = velocity;
            _animation.SetSpeed(velocity.magnitude);
        }

        private void Rotate()
        {
            transform.up = _inputService.LookDirection;
        }

        #endregion
    }
}