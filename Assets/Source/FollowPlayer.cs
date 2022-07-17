using UnityEngine;

namespace GMTKGame
{
    internal class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _player;

        private Transform _transform;
        private Vector3 _distanceToPlayer;

        private void Awake()
        {
            _transform = transform;
        }

        public void CalculateDistanceToPlayer()
        {
            _distanceToPlayer = _transform.position - _player.transform.position;
        }

        private void Update()
        {
            _transform.position = _distanceToPlayer + _player.transform.position;
        }
    }
}
