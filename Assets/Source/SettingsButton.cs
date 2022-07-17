using GMTKGame;
using UnityEngine;

namespace Assets.Source
{
    internal class SettingsButton : MonoBehaviour
    {
        private PlayerInputHandler _playerInputHandler;
        private bool _isInMenu;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !_isInMenu)
            {
                _isInMenu = true;
                _playerInputHandler.enabled = false;
            } else if (_isInMenu)
            {
                _playerInputHandler.enabled = true;
            }
        }
    }
}
