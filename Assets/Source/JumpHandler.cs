using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GMTKGame;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Source
{
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerPositionHandler))]
    [RequireComponent(typeof(PlayerMovement))]
    internal class JumpHandler : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private float _duration;
        [SerializeField] private float _jumpForce;

        private PlayerInputHandler _playerInputHandler;
        private PlayerPositionHandler _playerPositionHandler;
        private PlayerMovement _playerMovement;
        private Rigidbody _rigidbody;
        private float _maxKey;
        private float _minKey;
        private bool _isInJump;

        private void Awake()
        {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerPositionHandler = GetComponent<PlayerPositionHandler>();
            _playerMovement = GetComponent<PlayerMovement>();
            _rigidbody = GetComponent<Rigidbody>();

            var keyFrames = _jumpCurve.keys.ToList();
            _maxKey = keyFrames.Max(k => k.value);
            _minKey = keyFrames.Min(k => k.value);
        }

        private void OnNumberPressed(int number)
        {
            var direction = _playerPositionHandler.GetDirectionByNumber(number);
            if (direction == Direction.Up)
                OnJump();
        }

        private void OnAlternativeInput(Direction direction)
        {
            if (direction == Direction.Up)
                OnJump();
        }

        private void OnJump()
        {
            if (!_isInJump && _playerMovement.CurrentDirection == Direction.None)
            {
                _rigidbody.AddForce(new Vector3(0, _jumpForce, 0));
            }
        }

        private IEnumerator Jump(float duration)
        {
            float time = 0;
            Vector3 startPosition = transform.position;
            while (time < _duration)
            {
                var step = time / duration;
                var newPosition = new Vector3(startPosition.x, startPosition.y + _jumpCurve.Evaluate(step),
                    startPosition.z);
                transform.position = newPosition;
                time += Time.deltaTime;
                yield return null;
            }

            _isInJump = false;
        }

        private void OnEnable()
        {
            _playerInputHandler.NumberPressed += OnNumberPressed;
            _playerInputHandler.KeyPressed += OnAlternativeInput;
        }

        private void OnDisable()
        {
            _playerInputHandler.NumberPressed -= OnNumberPressed;
            _playerInputHandler.KeyPressed -= OnAlternativeInput;
        }
    }
}
