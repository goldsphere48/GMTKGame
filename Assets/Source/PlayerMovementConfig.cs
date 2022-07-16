using UnityEngine;

namespace Assets.Source
{
    internal class PlayerMovementConfig : MonoBehaviour
    {
        [SerializeField] private float _playerMoveAnimationDuration = 0.2f;
        [SerializeField] private float _gravity = 0.01f;
        [SerializeField] private float _jumpForce = 300;

        public float PlayerMoveAnimationDuration => _playerMoveAnimationDuration;
        public float Gravity => _gravity;
        public float JumpForce => _jumpForce;
    }
}
