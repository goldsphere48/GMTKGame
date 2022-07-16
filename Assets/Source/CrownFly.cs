using UnityEngine;

namespace GMTKGame
{
    internal class CrownFly : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _flyAnimationCurve;
        private Transform _transform;
        private float _time;
        private Vector3 _position;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _position = transform.localPosition;
        }

        private void Update()
        {
            var newPosition = new Vector3(_position.x,
                _position.y + _flyAnimationCurve.Evaluate(_time), _position.z);
            _transform.localPosition = newPosition;
            _time += Time.deltaTime;
        }
    }

}