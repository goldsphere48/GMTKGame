using UnityEngine;
using UnityEngine.UI;

namespace GMTKGame.Menu
{
    internal class QuitButton : MonoBehaviour
    {
        private Button _quitButton;

        private void Awake()
        {
            _quitButton = GetComponent<Button>();
            _quitButton.onClick.AddListener(Close);
        }

        private void Close()
        {
            Application.Quit();
        }
    }
}
