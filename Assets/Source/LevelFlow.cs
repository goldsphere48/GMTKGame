using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTKGame
{
    internal class LevelFlow : MonoBehaviour
    {
        [SerializeField] private List<WorldData> _worlds;
        private WorldData _currentWorld;
        private GameObject _currentLevelPrefab;

        public event Action LevelSpawned;

        public IReadOnlyList<WorldData> Worlds => _worlds;

        private void Awake()
        {
            _currentWorld = _worlds.Find(w => !w.Completed);
        }

        private void Start()
        {
            SpawnLevel();
        }

        private void SpawnLevel()
        {
            _currentLevelPrefab = Instantiate(_currentWorld.World);
            LevelSpawned?.Invoke();
        }

        public IEnumerator WinLevel()
        {
            _currentWorld.Completed = true;
            _currentWorld = GetNextLevel();
            _currentWorld.Unlocked = true;
            if (_currentWorld == null)
            {
                ClearProgress();
            }
            else
            {
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
