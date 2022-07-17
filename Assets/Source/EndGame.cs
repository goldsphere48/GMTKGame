using System.Collections;
using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    internal class EndGame : MonoBehaviour
    {
        private Checkpoint _finishCheckpoint;
        private PlayerInputHandler _playerInputHandler;
        private BouncePlayer _bouncePlayer;
        private World _world;
        private FollowPlayer _followPlayer;
        [SerializeField] private LevelFlow _levelFlow;

        private void OnCheckpointEntered()
        {
            _playerInputHandler.enabled = false;
            _followPlayer.enabled = false;
            Debug.Log("Finish!");
            StartCoroutine(Bounce());
        }

        private IEnumerator Bounce()
        {
            yield return new WaitForSeconds(1f);
            _bouncePlayer.Bounce();
            yield return new WaitForSeconds(2f);
            yield return _levelFlow.WinLevel();
        }

        private void OnLevelSpawned()
        {
            _world = FindObjectOfType<World>();
            _finishCheckpoint = _world.FinishCheckpoint;
            _bouncePlayer = FindObjectOfType<BouncePlayer>();
            _playerInputHandler = FindObjectOfType<PlayerInputHandler>();
            _followPlayer = FindObjectOfType<FollowPlayer>();
            _finishCheckpoint.CheckpointEntered += OnCheckpointEntered;
        }

        private void OnEnable()
        {
            _levelFlow.LevelSpawned += OnLevelSpawned;
        }

        private void OnDisable()
        {
            _finishCheckpoint.CheckpointEntered -= OnCheckpointEntered;
            _levelFlow.LevelSpawned -= OnLevelSpawned;
        }
    }
}
