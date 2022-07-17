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

        private WorldData _currentWorld;
        private GameObject _currentLevelPrefab;

        public event Action LevelSpawned;

        public IReadOnlyList<WorldData> Worlds => _worlds;
        public WorldData CurrentWorld => _currentWorld;

        private void Awake()
        {
            var initialLevelName = PlayerPrefs.GetString("InitialLevel");
            if (initialLevelName != null)
                _currentWorld = _worlds.Find(w => w.Name == initialLevelName);
            else
                _currentWorld = _worlds.Find(w => !w.Completed);

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
            _currentWorld.Completed = true;
            _currentWorld = GetNextLevel();
            if (_currentWorld == null)
            {
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
            return _worlds.Find(w => !w.Completed);
        }
    }
}
