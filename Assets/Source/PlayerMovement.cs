using System;
using System.Collections;
using System.Net.NetworkInformation;
using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    [RequireComponent(typeof(Rigidbody))]
    internal class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerMovementConfig _playerMovementConfig;

        private Transform _transform;
        private PlayerInputHandler _playerInputHandler;
        private PlayerPositionHandler _playerPositionHandler;
        private JumpHandler _jumpHandler;
        private Rigidbody _rigidbody;
        private BoxCollider _boxCollider;

        private Direction _currentDirection = Direction.None;

        public Direction CurrentDirection => _currentDirection;

        private void Awake()
        {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerPositionHandler = GetComponent<PlayerPositionHandler>();
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
            _jumpHandler = GetComponent<JumpHandler>();
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void OnNumberPressed(int number)
        {
            var direction = _playerPositionHandler.GetDirectionByNumber(number);
            if (direction != Direction.None)
                OnMoveInDirection(direction);
        }

        private void OnMoveInDirection(Direction direction)
        {
            if (_currentDirection == Direction.None && direction != Direction.Up && CanMoveInDirection(direction.ToVector3()))
            {
                _rigidbody.velocity = Vector3.zero;
                _currentDirection = direction;
                var target = _transform.position + direction.ToVector3();
                StartCoroutine(LerpPosition(target, _playerMovementConfig.PlayerMoveAnimationDuration));
            }
        }

        private bool CanMoveInDirection(Vector3 direction)
        {
            return !Physics.Raycast(transform.position, direction, 0.5f);
        }

        private void OnEnable()
        {
            _playerInputHandler.NumberPressed += OnNumberPressed;
            _playerInputHandler.KeyPressed += OnMoveInDirection;
        }

        private void OnDisable()
        {
            _playerInputHandler.NumberPressed -= OnNumberPressed;
            _playerInputHandler.KeyPressed -= OnMoveInDirection;
        }

        private IEnumerator LerpPosition(Vector3 targetPosition, float duration)
        {
            float time = 0;
            Vector3 startPosition = transform.position;
            while (time < duration)
            {
                var step = time / duration;
                if (_jumpHandler.IsPlayerInAir())
                    targetPosition = new Vector3(targetPosition.x, targetPosition.y - _playerMovementConfig.Gravity, targetPosition.z);
                transform.position = Vector3.Lerp(startPosition, targetPosition, step);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
            _currentDirection = Direction.None;
        }
    }
}
