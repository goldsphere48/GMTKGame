using UnityEngine;

namespace GMTKGame
{
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerPositionHandler))]
    internal class PlayerMovement : MonoBehaviour
    {
        private PlayerInputHandler _playerInputHandler;
        private PlayerPositionHandler _playerPositionHandler;

        private void Awake()
        {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerPositionHandler = GetComponent<PlayerPositionHandler>();
        }

        private void OnNumberPressed(int number)
        {
            Debug.Log(_playerPositionHandler.GetDirectionByNumber(number));
        }

        private void OnEnable()
        {
            _playerInputHandler.NumberPressed += OnNumberPressed;
        }

        private void OnDisable()
        {
            _playerInputHandler.NumberPressed -= OnNumberPressed;
        }

        private void Update()
        {

        }
    }
}
