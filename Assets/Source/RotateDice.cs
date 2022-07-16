using UnityEngine;

namespace GMTKGame
{
    class RotateDice : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationSpeed;
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            _transform.rotation = Quaternion.Euler(_rotationSpeed) * _transform.rotation;
        }
    }
}
