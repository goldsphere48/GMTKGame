using UnityEngine;

namespace GMTKGame.Mechanics
{
    [RequireComponent(typeof(BoxCollider))]
    internal class Spikes : MonoBehaviour
    {
        [SerializeField] private AudioSource _damageAudio;
        private Player _player;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<Player>() != null)
            {
                _damageAudio.Play();
                _player.Hit();
            }
        }
    }
}
