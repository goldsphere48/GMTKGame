using System;
using System.Collections.Generic;
using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private List<KeyCode> _validKeyCodes;
        private Dictionary<KeyCode, Direction> _keyDirections;

        public event Action<int> NumberPressed;
        public event Action<Direction, int> KeyPressed;
        private PlayerPositionHandler _playerPositionHandler;
        private RespawnSystem _respawnSystem;

        private void Awake()
        {
            _validKeyCodes = new List<KeyCode>
            {
                KeyCode.Alpha1,
                KeyCode.Alpha2,
                KeyCode.Alpha3,
                KeyCode.Alpha4,
                KeyCode.Alpha5,
                KeyCode.Alpha6,
            };

            _keyDirections = new Dictionary<KeyCode, Direction>
            {
                { KeyCode.W, Direction.Forward },
                { KeyCode.A, Direction.Left },
                { KeyCode.S, Direction.Backward },
                { KeyCode.D, Direction.Right },
                { KeyCode.Space, Direction.Up },
            };

            _playerPositionHandler = GetComponent<PlayerPositionHandler>();
            _respawnSystem = FindObjectOfType<RespawnSystem>();
        }

        void Update()
        {
            foreach (var keyDirection in _keyDirections)
            {
                if (Input.GetKeyDown(keyDirection.Key))
                {
                    KeyPressed?.Invoke(keyDirection.Value, _playerPositionHandler.DirectionsToNumber[keyDirection.Value]);
                }
            }
            foreach (var validKeyCode in _validKeyCodes)
            {
                if (Input.GetKeyDown(validKeyCode))
                {
                    NumberPressed?.Invoke(validKeyCode.ToInt());
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _respawnSystem.RespawnPlayer();
            }
        }
    }

}