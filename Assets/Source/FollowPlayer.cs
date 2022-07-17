using System.Collections;
using UnityEngine;

namespace GMTKGame
{
    internal class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private Vector3 _distanceToPlayer;
        [SerializeField] private LevelFlow _levelFlow;
        private Transform _transform;
        private World _world;

        private void Awake()
        {
            _transform = transform;
            _transform.position = _distanceToPlayer;
            _levelFlow.LevelSpawned += OnLevelSpawned;
        }

        private void Update()
        {
            _transform.position = _distanceToPlayer + _player.transform.position;
        }

        public void LookAt(Transform transform)
        {
            _transform.position = _distanceToPlayer + transform.position;
        }

        private void OnLevelSpawned()
        {
            _world = FindObjectOfType<World>();
            StartCoroutine(OnLateLevelSpawned());
        }

        private IEnumerator OnLateLevelSpawned()
        {
            yield return null;
            LookAt(_world.StartCheckpoint.transform);
        }
    }
}
