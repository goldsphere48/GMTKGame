using System.Collections;
using UnityEngine;

namespace GMTKGame
{
    internal class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private PlayerPositionHandler _playerPositionHandler;
        [SerializeField] private float _duration;

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
                OnRotateInDirection(direction);
        }

        private void OnRotateInDirection(Direction direction)
        {
            if (_currentDirection == Direction.None && direction != Direction.Up)
            {
                _currentDirection = direction;
                var target = Quaternion.Euler(direction.ToVector3Angle()) * _transform.rotation;
                StartCoroutine(LerpRotation(target, _duration));
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
            _currentDirection = Direction.None;
        }
    }
}
