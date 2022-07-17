using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GMTKGame
{
    internal class GameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseCanvas;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _winLevelMenu;
        [SerializeField] private LevelFlow _levelFlow;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _mainMenuButtonSettings;
        [SerializeField] private Button _quitGameButton;

        [SerializeField] private GameObject _topLeft;
        [SerializeField] private GameObject _topRight;
        [SerializeField] private GameObject _bottomLeft;

        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private Timer _timer;

        private bool _isEscape;

        private bool _isInMenu;

        private void Awake()
        {
            _resumeButton.onClick.AddListener(OnResumeButtonClick);
            _levelFlow = FindObjectOfType<LevelFlow>();
            _levelFlow.WinLastLevel += OnWinLastLevel;
            _mainMenuButton.onClick.AddListener(OpenMenu);
            _mainMenuButtonSettings.onClick.AddListener(OpenMenu);
            _quitGameButton.onClick.AddListener(Close);
        }

        private void Close()
        {
            Application.Quit();
        }

        private void OnWinLastLevel()
        {
            _topLeft.SetActive(false);
            _topRight.SetActive(false);
            _bottomLeft.SetActive(false);
            _pauseCanvas.SetActive(true);
            _winLevelMenu.SetActive(true);
        }

        private void OpenMenu()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        private void OnResumeButtonClick()
        {
            _timer.enabled = true;
            _playerInputHandler.enabled = true;
            _pauseCanvas.SetActive(false);
            _pauseMenu.SetActive(false);
            _isInMenu = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !_isInMenu)
            {
                _timer.enabled = false;
                _playerInputHandler.enabled = false;
                _isInMenu = true;
                _pauseCanvas.SetActive(true);
                _pauseMenu.SetActive(true);
                _isEscape = true;
            } else if (Input.GetKeyDown(KeyCode.Escape) && _isInMenu)
            {
                OnResumeButtonClick();
            }

            if (Input.GetKeyUp(KeyCode.Escape) && _isEscape)
            {
                _isEscape = false;
            }
        }
    }
}
