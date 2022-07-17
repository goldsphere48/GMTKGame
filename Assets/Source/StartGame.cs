using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    internal class StartGame : MonoBehaviour
    {
        private PlayerSpawn _playerSpawn;
        private Checkpoint _startCheckpoint;
        private World _world;

        private void Awake()
        {
            _world = GetComponent<World>();
            _startCheckpoint = _world.StartCheckpoint;
            _playerSpawn = FindObjectOfType<PlayerSpawn>();
        }

        private void Start()
        {
            _playerSpawn.Spawn(_startCheckpoint);
        }
    }
}
