﻿using System;
using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;

namespace GMTKGame
{
    internal class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _duration;

        private Transform _transform;
        private PlayerInputHandler _playerInputHandler;
        private PlayerPositionHandler _playerPositionHandler;

        private Direction _currentDirection = Direction.None;

        public Direction CurrentDirection => _currentDirection;

        private void Awake()
        {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerPositionHandler = GetComponent<PlayerPositionHandler>();
            _transform = GetComponent<Transform>();
        }

        private void OnNumberPressed(int number)
        {
            var direction = _playerPositionHandler.GetDirectionByNumber(number);
            if (direction != Direction.None)
                OnMoveInDirection(direction);
        }

        private void OnMoveInDirection(Direction direction)
        {
            if (_currentDirection == Direction.None && direction != Direction.Up)
            {
                _currentDirection = direction;
                var target = _transform.position + direction.ToVector3();
                StartCoroutine(LerpPosition(target, _duration));
            }
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
                transform.position = Vector3.Lerp(startPosition, targetPosition, step);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
            _currentDirection = Direction.None;
        }
    }
}
