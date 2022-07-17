using System;
using UnityEngine;

namespace GMTKGame
{
    internal class DeathPlane : MonoBehaviour
    {
        [SerializeField] private AudioSource _audio;
        public event Action Dead; 
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<Player>() != null)
            {
                _audio.Play();
                Dead?.Invoke();
            }
        }
    }
}
