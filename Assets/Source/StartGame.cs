using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    internal class StartGame : MonoBehaviour
    {
        [SerializeField] private LevelFlow _levelFlow;
        private PlayerSpawn _playerSpawn;
        private Checkpoint _startCheckpoint;
        private World _world;

        private void Awake()
        {
            _levelFlow.LevelSpawned += OnLevelSpawned;
        }

        private void OnLevelSpawned()
        {
            _world = GetComponent<World>();
            _startCheckpoint = _world.StartCheckpoint;
            _playerSpawn = FindObjectOfType<PlayerSpawn>();
            _playerSpawn.Spawn(_startCheckpoint);
        }
    }
}
