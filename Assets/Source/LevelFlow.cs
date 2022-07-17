using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GMTKGame
{
    internal class LevelFlow : MonoBehaviour
    {
        [SerializeField] private List<WorldData> _worlds;
        [SerializeField] private TextMeshProUGUI _levelName;
        [SerializeField] private TextMeshProUGUI _levelNumber;

        [SerializeField] private AudioSource _winSound;
        
        private WorldData _currentWorld;
        private GameObject _currentLevelPrefab;

        public event Action LevelSpawned;
        public event Action LevelFinished;
        public event Action WinLastLevel;

        public IReadOnlyList<WorldData> Worlds => _worlds;
        public WorldData CurrentWorld => _currentWorld;

        private void Awake()
        {
            var initialLevelName = PlayerPrefs.GetString("InitialLevel");
            if (!string.IsNullOrEmpty(initialLevelName))
                _currentWorld = _worlds.Find(w => w.Name == initialLevelName);
            else
                _currentWorld = _worlds[0];

        }

        private void Start()
        {
            SpawnLevel();
        }

        private void SpawnLevel()
        {
            _currentLevelPrefab = Instantiate(_currentWorld.World);
            _levelName.text = _currentWorld.Name;
            _levelNumber.text = $"LEVEL {_worlds.IndexOf(_currentWorld) + 1}";
            LevelSpawned?.Invoke();
        }

        public IEnumerator WinLevel()
        {
            _winSound.Play();
            LevelFinished?.Invoke();
            _currentWorld.Completed = true;
            _currentWorld = GetNextLevel();
            if (_currentWorld == null)
            {
                WinLastLevel?.Invoke();
                ClearProgress();
            }
            else
            {
                _currentWorld.Unlocked = true;
                Destroy(_currentLevelPrefab);
                yield return null;
                SpawnLevel();
            }
        }

        private void ClearProgress()
        {
            foreach (var worldData in _worlds)
            {
                worldData.Completed = false;
            }
        }

        private WorldData GetNextLevel()
        {
            var currentIndex = _worlds.IndexOf(_currentWorld);
            if (currentIndex + 1 < _worlds.Count)
            {
                return _worlds[currentIndex + 1];
            }

            return null;
        }
    }
}
