using UnityEngine;

namespace GMTKGame
{
    internal class SideProjection : MonoBehaviour
    {
        [SerializeField] private bool _highest;
        [SerializeField] private bool _left;
        [SerializeField] private bool _rigth;
        [SerializeField] private bool _backward;
        [SerializeField] private bool _forward;

        private PlayerPositionHandler _playerPositionHandler;
        private SideProjectionMaterialsStore _sideProjectionMaterialsStore;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _sideProjectionMaterialsStore = FindObjectOfType<SideProjectionMaterialsStore>();
            _playerPositionHandler = FindObjectOfType<PlayerPositionHandler>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _playerMovement.Moved += ChangeMaterial;
        }

        public void ChangeMaterial()
        {
            int num = 1;
            if (_highest)
                num = _playerPositionHandler.HighEdge.EdgeNumber;
            else if (_left)
                num = _playerPositionHandler.LeftEdge.EdgeNumber;
            else if (_rigth)
                num = _playerPositionHandler.RightEdge.EdgeNumber;
            else if (_backward)
                num = _playerPositionHandler.BackwardEdge.EdgeNumber;
            else if (_forward)
                num = _playerPositionHandler.ForwardEdge.EdgeNumber;

            GetComponent<Renderer>().material = _sideProjectionMaterialsStore.GetMaterial(num);
        }
    }
}
