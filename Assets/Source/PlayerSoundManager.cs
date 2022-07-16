using GMTKGame;
using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(PlayerMovementConfig))]
    internal class PlayerSoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _movementSounds;
        [SerializeField] private AudioSource _jumpSound;
        [SerializeField] private AudioSource _hitSound;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnMoved(int number)
        {
            _movementSounds[number - 1].Play();
        }

        private void OnJumped(int number)
        {
            _jumpSound.Play();
            _movementSounds[number - 1].Play();
        }

        private void OnHitted()
        {
            _hitSound.Play();
        }

        private void OnEnable()
        {
            _playerMovement.Moved += OnMoved;
            _playerMovement.Jumped += OnJumped;
            _playerMovement.Hitted += OnHitted;
        }

        private void OnDisable()
        {
            _playerMovement.Moved -= OnMoved;
            _playerMovement.Jumped -= OnJumped;
            _playerMovement.Hitted -= OnHitted;
        }
    }
}
