using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    internal class StartGame : MonoBehaviour
    {
        private PlayerSpawn _playerSpawn;
        [SerializeField] private Checkpoint _startCheckpoint;

        private void Awake()
        {
            _playerSpawn = FindObjectOfType<PlayerSpawn>();
        }

        private void Start()
        {
            _playerSpawn.Spawn(_startCheckpoint);
        }
    }
}
