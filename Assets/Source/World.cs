using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GMTKGame
{
    internal class World : MonoBehaviour
    {
        [SerializeField] private LevelFlow _levelFlow;
        public int LastCheckpointId;
        public int MaxCheckpointId;
        private Checkpoint _startCheckpoint;
        private Checkpoint _finishCheckpoint;
        private List<Checkpoint> _checkpoints;

        public Checkpoint StartCheckpoint => _startCheckpoint;
        public Checkpoint FinishCheckpoint => _finishCheckpoint;
        public Checkpoint LastSavedCheckpoint => _checkpoints[LastCheckpointId - 1];

        public event Action CheckpointsStored; 

        private void OnEnable()
        {
            _levelFlow.LevelSpawned += OnLevelSpawned;
        }

        private void OnDisable()
        {
            _levelFlow.LevelSpawned -= OnLevelSpawned;
        }

        private void OnLevelSpawned()
        {
            LastCheckpointId = 1;
            _checkpoints = FindObjectsOfType<Checkpoint>().ToList();
            _checkpoints = _checkpoints.OrderBy(c => c.Id).ToList();
            _startCheckpoint = _checkpoints.Aggregate((c1, c2) => c1.Id < c2.Id ? c1 : c2);
            _finishCheckpoint = _checkpoints.Aggregate((c1, c2) => c1.Id > c2.Id ? c1 : c2);
            CheckpointsStored?.Invoke();
        }
    }
}
