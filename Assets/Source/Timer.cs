using System.Collections;
using TMPro;
using UnityEngine;

namespace GMTKGame
{
    internal class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        private LevelFlow _levelFlow;
        private int _time;

        private void Awake()
        {
            _levelFlow = FindObjectOfType<LevelFlow>();
            _levelFlow.LevelSpawned += OnLevelSpawned;
            _levelFlow.LevelFinished += OnLevelFinished;
        }

        private void OnLevelSpawned()
        {
            _time = 0;
            StartCoroutine(StartTimer());
        }

        private void OnLevelFinished()
        {
            _levelFlow.CurrentWorld.Time = _time;
        }

        private IEnumerator StartTimer()
        {
            while (true)
            {
                if (enabled)
                {
                    yield return new WaitForSeconds(1f);
                    _time += 1;
                    int minutes = (int)(_time / 60);
                    int seconds = (int)(_time % 60);
                    _timerText.text = $"{minutes:00}:{seconds:00}";
                }
            }
        }
    }
}
