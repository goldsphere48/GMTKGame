using GMTKGame;
using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInputHandler))]
    internal class PlayerFreezeController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private PlayerInputHandler _playerInputHandler;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerInputHandler = GetComponent<PlayerInputHandler>();
        }

        public void Freeze()
        {
            _rigidbody.useGravity = true;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            _playerInputHandler.enabled = true;
        }

        public void Unfreeze(bool useGravity = false)
        {
            _rigidbody.useGravity = useGravity;
            _rigidbody.constraints = RigidbodyConstraints.None;
            _playerInputHandler.enabled = false;
        }
    }
}
