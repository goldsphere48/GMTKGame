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

        private bool _isEscape;

        private bool _isInMenu;

        private void Awake()
        {
            _resumeButton.onClick.AddListener(OnResumeButtonClick);
            _levelFlow = FindObjectOfType<LevelFlow>();
            _levelFlow.WinLastLevel += OnWinLastLevel;
            _mainMenuButton.onClick.AddListener(OpenMenu);
        }

        private void OnWinLastLevel()
        {
            _pauseCanvas.SetActive(true);
            _winLevelMenu.SetActive(true);
        }

        private void OpenMenu()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        private void OnResumeButtonClick()
        {
            _pauseCanvas.SetActive(false);
            _pauseMenu.SetActive(false);
            _isInMenu = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !_isInMenu)
            {
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
