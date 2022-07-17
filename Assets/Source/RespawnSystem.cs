using UnityEngine;

namespace GMTKGame
{
    internal class RespawnSystem : MonoBehaviour
    {
        [SerializeField] private DeathPlane _deathPlane;
        [SerializeField] private PlayerSpawn _playerSpawn;
        [SerializeField] private FollowPlayer _followPlayer;
        [SerializeField] private LevelFlow _levelFlow;

        private World _world;

        private void OnDead()
        {
            _followPlayer.LookAt(_world.LastSavedCheckpoint.transform);
            _playerSpawn.Spawn(_world.LastSavedCheckpoint);
        }

        private void OnLevelSpawned()
        {
            _world = GetComponent<World>();
        }

        private void Awake()
        {
            _levelFlow.LevelSpawned += OnLevelSpawned;
            _deathPlane.Dead += OnDead;
        }
    }
}
