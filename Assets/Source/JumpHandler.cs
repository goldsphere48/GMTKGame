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
        [SerializeField] private PlayerMovementConfig _playerMovementConfig;

        private PlayerInputHandler _playerInputHandler;
        private PlayerPositionHandler _playerPositionHandler;
        private PlayerMovement _playerMovement;
        private Rigidbody _rigidbody;

        public event Action<int> Jumped; 

        private void Awake()
        {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerPositionHandler = GetComponent<PlayerPositionHandler>();
            _playerMovement = GetComponent<PlayerMovement>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnNumberPressed(int number)
        {
            var direction = _playerPositionHandler.GetDirectionByNumber(number);
            if (direction == Direction.Up)
                OnJump();
        }

        private void OnAlternativeInput(Direction direction, int number)
        {
            if (direction == Direction.Up)
                OnJump();
        }

        public bool IsPlayerInAir()
        {
            return _rigidbody.velocity.magnitude >= 0.1f;
        }

        private void OnJump()
        {
            if (!IsPlayerInAir() && _playerMovement.CurrentDirection == Direction.None)
            {
                Jumped?.Invoke(_playerPositionHandler.HighEdge.EdgeNumber);
                _rigidbody.AddForce(new Vector3(0, _playerMovementConfig.JumpForce, 0));
            }
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
