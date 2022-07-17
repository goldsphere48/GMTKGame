using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(Rigidbody))]
    internal class PlayerFreezeController : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Freeze()
        {
            _rigidbody.useGravity = true;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }

        public void Unfreeze()
        {
            _rigidbody.useGravity = false;
            _rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}
