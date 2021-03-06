using System;
using System.Linq;
using Assets.Source;
using UnityEngine;
using Random = System.Random;

namespace GMTKGame
{
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerFreezeController))]
    [RequireComponent(typeof(Rigidbody))]
    internal class PlayerSpawn : MonoBehaviour
    {
        [SerializeField] private Transform _cubeTransform;
        [SerializeField] private float _startHeight = 10;
        private FollowPlayer _followPlayerScript;
        private PlayerInputHandler _playerInputHandler;
        private PlayerFreezeController _playerFreezeController;
        private Transform _transform;
        private Rigidbody _rigidbody;
        private SideProjectionMaterialsStore _sideProjectionMaterialsStore;
        
        public event Action Spawned; 


        private void Awake()
        {
            _transform = transform;
            _followPlayerScript = FindObjectOfType<FollowPlayer>();
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerFreezeController = GetComponent<PlayerFreezeController>();
            _rigidbody = GetComponent<Rigidbody>();
            _sideProjectionMaterialsStore = FindObjectOfType<SideProjectionMaterialsStore>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (enabled)
            {
                Spawned?.Invoke();
                _followPlayerScript.enabled = true;
                _playerInputHandler.enabled = true;
                enabled = false;
            }
        }

        public void Spawn(Checkpoint checkpoint)
        {
            enabled = true;
            _rigidbody.velocity = Vector3.zero;
            _playerFreezeController.Freeze();
            _followPlayerScript.enabled = false;
            _playerInputHandler.enabled = false;
            enabled = true;
            AlignRotation();
            RandomRotate();
            PlaceUnderCheckpoint(checkpoint);
            _sideProjectionMaterialsStore.SetupProjections();
        }

        private void PlaceUnderCheckpoint(Checkpoint checkpoint)
        {
            var start = checkpoint.transform.position;
            _transform.position = new Vector3(start.x, _startHeight, start.z);
        }

        private void AlignRotation()
        {
            _transform.eulerAngles = Vector3.zero;
            _cubeTransform.eulerAngles = Vector3.zero;
            _rigidbody.rotation = Quaternion.Euler(Vector3.zero);
        }

        public void RandomRotate()
        {
            var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
            var random = new Random();
            for (int i = 0; i < 5; ++i)
                Rotate(directions[random.Next(directions.Count)]);
            
        }

        private void Rotate(Direction direction)
        {
            var rotation = direction.ToVector3Angle();
            _cubeTransform.Rotate(rotation, Space.World);
        }
    }
}
