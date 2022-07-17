using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GMTKGame
{
    internal class World : MonoBehaviour
    {
        [SerializeField] private WorldData _worldData;
        private Checkpoint _startCheckpoint;
        private Checkpoint _finishCheckpoint;
        private List<Checkpoint> _checkpoints;

        public Checkpoint StartCheckpoint => _startCheckpoint;
        public Checkpoint FinishCheckpoint => _finishCheckpoint;
        public Checkpoint LastSavedCheckpoint => _checkpoints[_worldData.LastCheckpointId];

        private void Awake()
        {
            _checkpoints = FindObjectsOfType<Checkpoint>().ToList();
            _startCheckpoint = _checkpoints.Aggregate((c1, c2) => c1.Id < c2.Id ? c1 : c2);
            _finishCheckpoint = _checkpoints.Aggregate((c1, c2) => c1.Id > c2.Id ? c1 : c2);
        }

        public WorldData WorldData => _worldData;
    }
}
