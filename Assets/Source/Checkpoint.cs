using System;
using UnityEngine;

namespace GMTKGame
{
    [RequireComponent(typeof(BoxCollider))]
    internal class Checkpoint : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private AudioSource _audioSource;
        private World _world;

        public int Id => _id;

        public event Action CheckpointEntered;

        private void Awake()
        {
            _world = FindObjectOfType<World>();
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                UseCheckpoint();
            }
        }

        private void UseCheckpoint()
        {
            if (_world.LastCheckpointId < Id)
            {
                _audioSource.Play();
                _world.LastCheckpointId = Id;
                CheckpointEntered?.Invoke();
                Debug.Log("Checkpoint!");
            }
        }
    }
}
