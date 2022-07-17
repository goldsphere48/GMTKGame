using UnityEngine;

namespace GMTKGame
{
    internal class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private Vector3 _distanceToPlayer;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            _transform.position = _distanceToPlayer;
        }

        private void Update()
        {
            _transform.position = _distanceToPlayer + _player.transform.position;
        }

        public void LookAt(Transform transform)
        {
            _transform.position = _distanceToPlayer + transform.position;
        }
    }
}
