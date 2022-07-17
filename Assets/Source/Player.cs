using System;
using System.Collections;
using Assets.Source;
using UnityEngine;
using Random = System.Random;

namespace GMTKGame
{
    [RequireComponent(typeof(Rigidbody))]
    internal class Player : MonoBehaviour
    {
        [SerializeField] private float _throwForce = 200;
        [SerializeField] private LevelFlow _levelFlow;
        [SerializeField] private bool _mainMenuPlayer;
        private Rigidbody _rigidbody;
        private FollowPlayer _followPlayer;
        private PlayerMovement _playerMovement;
        private RespawnSystem _respawnSystem;
        private PlayerFreezeController _playerFreezeController;
        private bool _isRespawn;


        private void Awake()
        {
            _playerFreezeController = GetComponent<PlayerFreezeController>();
            _rigidbody = GetComponent<Rigidbody>();
            _followPlayer = FindObjectOfType<FollowPlayer>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _respawnSystem = FindObjectOfType<RespawnSystem>();
        }


        public void Hit()
        {
            if (!_isRespawn)
            {
                _isRespawn = true;
                var random = new Random();
                _playerFreezeController.Unfreeze(true);
                var forceVector = Vector3.up;
                forceVector.x = (float)random.NextDouble();
                forceVector.z = (float)random.NextDouble();
                _rigidbody.AddForce(forceVector * _throwForce);
                StartCoroutine(Die());
            }
        }

        private IEnumerator Die()
        {
            yield return new WaitForSeconds(2f);
            _respawnSystem.RespawnPlayer();
            _isRespawn = false;
        }
    }
}
