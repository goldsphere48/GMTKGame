using UnityEngine;

namespace GMTKGame
{
    internal class RespawnSystem : MonoBehaviour
    {
        [SerializeField] private DeathPlane _deathPlane;
        [SerializeField] private PlayerSpawn _playerSpawn;
        [SerializeField] private FollowPlayer _followPlayer;

        private World _world;

        private void Awake()
        {
            _world = GetComponent<World>();
        }

        private void OnDead()
        {
            _followPlayer.LookAt(_world.LastSavedCheckpoint.transform);
            _playerSpawn.Spawn(_world.LastSavedCheckpoint);
        }

        private void OnEnable()
        {
            _deathPlane.Dead += OnDead;
        }

        private void OnDisable()
        {
            _deathPlane.Dead -= OnDead;
        }
    }
}
