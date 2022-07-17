using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerFreezeController))]
    internal class BouncePlayer : MonoBehaviour
    {
        [SerializeField] private float _bounceForce = 500;
        [SerializeField] private float _torque = 100;
        private Rigidbody _rigidbody;
        private PlayerFreezeController _playerFreezeController;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerFreezeController = GetComponent<PlayerFreezeController>();
        }

        public void Bounce()
        {
            _playerFreezeController.Unfreeze();
            _rigidbody.AddForce(Vector3.up * _bounceForce);
            _rigidbody.AddTorque(Vector3.up * _torque);
        }
    }
}
