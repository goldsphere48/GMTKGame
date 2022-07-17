using System.Collections;
using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    internal class Coin : MonoBehaviour
    {
        private AudioSource _audio;
        private UserWallet _userWallet;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
            _userWallet = FindObjectOfType<UserWallet>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<Player>() != null)
            {
                StartCoroutine(PlaySound());
            }
        }

        private IEnumerator PlaySound()
        {
            _audio.Play();
            _meshRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }
    }
}
