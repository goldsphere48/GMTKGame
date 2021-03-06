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
        public event Action<int> Move;
        public event Action Moved;
        public event Action<int> Jumped;
        public event Action Hitted;

        [SerializeField] private PlayerMovementConfig _playerMovementConfig;

        private Transform _transform;
        private PlayerInputHandler _playerInputHandler;
        private PlayerPositionHandler _playerPositionHandler;
        private JumpHandler _jumpHandler;
        private Rigidbody _rigidbody;
        private DeathPlane _deathPlane;
        private PlayerSpawn _playerSpawn;
        [SerializeField] private bool _isInGameMenu;

        private Direction _currentDirection = Direction.None;

        public Direction CurrentDirection => _currentDirection;
        private bool _isDead;

        private void Awake()
        {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerPositionHandler = GetComponent<PlayerPositionHandler>();
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
            _jumpHandler = GetComponent<JumpHandler>();
            _deathPlane = FindObjectOfType<DeathPlane>();
            _playerSpawn = FindObjectOfType<PlayerSpawn>();
            _playerSpawn.Spawned += OnAlive;
            if (!_isInGameMenu)
            {
                _deathPlane.Dead += OnDead;
            }
        }

            private void OnDead()
        {
            _isDead = true;
        }

        private void OnAlive()
        {
            _isDead = false;
        }

        private void OnNumberPressed(int number)
        {
            var direction = _playerPositionHandler.GetDirectionByNumber(number);
            if (direction != Direction.None)
                OnMoveInDirection(direction, number);
        }

        private void OnMoveInDirection(Direction direction, int number)
        {
            if (_currentDirection == Direction.None && direction != Direction.Up)
            {
                if (CanMoveInDirection(direction.ToVector3()))
                {
                    _rigidbody.velocity = Vector3.zero;
                    _currentDirection = direction;
                    var target = _transform.position + direction.ToVector3();
                    StartCoroutine(LerpPosition(target, _playerMovementConfig.PlayerMoveAnimationDuration));
                    Move?.Invoke(number);
                } 
                else
                {
                    Hitted?.Invoke();
                }
            }
        }

        private bool CanMoveInDirection(Vector3 center)
        {
            return !Raycast(center);
        }

        private bool Raycast(Vector3 direction)
        {
            RaycastHit hit;
            var result = Physics.Raycast(transform.position, direction, out hit, 0.8f);
            var isCoin = false;
            if (hit.transform != null)
                isCoin = hit.transform.gameObject.GetComponent<Coin>() != null;
            return result && !isCoin;
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
                if (_isDead)
                    break;

                var step = time / duration;
                if (_jumpHandler.IsPlayerInAir())
                    targetPosition = new Vector3(targetPosition.x, targetPosition.y - _playerMovementConfig.Gravity, targetPosition.z);
                transform.position = Vector3.Lerp(startPosition, targetPosition, step);
                time += Time.deltaTime;
                yield return null;
            }

            if (!_isDead)
            {
                transform.position = targetPosition;
            }

            _currentDirection = Direction.None;
            Moved?.Invoke();
        }
    }
}
