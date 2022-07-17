using System;
using UnityEngine;

namespace GMTKGame
{
    internal class DeathPlane : MonoBehaviour
    {
        public event Action Dead; 
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<Player>() != null)
            {
                Dead?.Invoke();
            }
        }
    }
}
