using System.Collections;
using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    internal class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private PlayerPositionHandler _playerPositionHandler;
        [SerializeField] private PlayerMovementConfig _playerMovementConfig;

        private Transform _transform;

        private Direction _currentDirection = Direction.None;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void OnNumberPressed(int number)
        {
            var direction = _playerPositionHandler.GetDirectionByNumber(number);
            if (direction != Direction.None)
                OnRotateInDirection(direction, number);
        }

        private void OnRotateInDirection(Direction direction, int number)
        {
            if (_currentDirection == Direction.None && direction != Direction.Up)
            {
                _currentDirection = direction;
                var target = Quaternion.Euler(direction.ToVector3Angle()) * _transform.rotation;
                StartCoroutine(LerpRotation(target, _playerMovementConfig.PlayerMoveAnimationDuration));
            }
        }

        private void OnEnable()
        {
            _playerInputHandler.NumberPressed += OnNumberPressed;
            _playerInputHandler.KeyPressed += OnRotateInDirection;
        }

        private void OnDisable()
        {
            _playerInputHandler.NumberPressed -= OnNumberPressed;
            _playerInputHandler.KeyPressed -= OnRotateInDirection;
        }

        private IEnumerator LerpRotation(Quaternion targetAngle, float duration)
        {
            float time = 0;
            Quaternion startQuaternion = transform.rotation;
            while (time < duration)
            {
                var step = time / duration;
                transform.rotation = Quaternion.Lerp(startQuaternion, targetAngle, step);
                time += Time.deltaTime;
                yield return null;
            }

            transform.rotation = targetAngle;
            _currentDirection = Direction.None;
        }
    }
}
