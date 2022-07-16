using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    internal class Coin : MonoBehaviour
    {
        private AudioSource _audio;
        private UserWallet _userWallet;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
            _userWallet = FindObjectOfType<UserWallet>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                _audio.Play();
                // _userWallet.AddCoin();
                Destroy(gameObject);
            }
        }
    }
}
