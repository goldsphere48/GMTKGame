using System.Linq;
using UnityEngine;

namespace GMTKGame
{
    internal class World : MonoBehaviour
    {
        [SerializeField] private WorldData _worldData;
        private Checkpoint _startCheckpoint;
        private Checkpoint _finishCheckpoint;

        public Checkpoint StartCheckpoint => _startCheckpoint;
        public Checkpoint FinishCheckpoint => _finishCheckpoint;

        private void Awake()
        {
            var checkpoints = FindObjectsOfType<Checkpoint>().ToList();
            _startCheckpoint = checkpoints.Aggregate((c1, c2) => c1.Id < c2.Id ? c1 : c2);
            _finishCheckpoint = checkpoints.Aggregate((c1, c2) => c1.Id > c2.Id ? c1 : c2);
        }

        public WorldData WorldData => _worldData;
    }
}
