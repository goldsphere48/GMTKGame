using System;
using UnityEngine;

namespace GMTKGame
{
    [RequireComponent(typeof(BoxCollider))]
    internal class Checkpoint : MonoBehaviour
    {
        [SerializeField] private int _id;
        private WorldData _worldData;

        public int Id => _id;

        public event Action CheckpointEntered;

        private void Awake()
        {
            var world = FindObjectOfType<World>();
            _worldData = world.WorldData;
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
            if (_worldData.LastCheckpointId < Id)
            {
                _worldData.LastCheckpointId = Id;
                CheckpointEntered?.Invoke();
                Debug.Log("Checkpoint!");
            }
        }
    }
}
