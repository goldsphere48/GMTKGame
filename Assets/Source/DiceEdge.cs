using UnityEngine;

namespace GMTKGame
{
    internal class DiceEdge : MonoBehaviour
    {
        [SerializeField] private int _edgeNumber;

        private Transform _transform;

        public Vector3 Position => transform.position;
        public Vector3 LocalPosition => _transform.localPosition;
        public int EdgeNumber => _edgeNumber;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }
    }
}
