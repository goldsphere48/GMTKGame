using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTKGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source
{
    internal class UserWallet : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _collectedCoinsText;
        public int Value { get; private set; }
        private int _maxCoins;
        [SerializeField] private LevelFlow _levelFlow;

        private void Awake()
        {
            _levelFlow.LevelSpawned += OnLevelSpawned;
        }

        private void OnLevelSpawned()
        {
            Value = 0;
            _maxCoins = _levelFlow.CurrentWorld.CoinsTotal;
            _collectedCoinsText.text = $"{Value} / {_maxCoins}";
        }

        public void AddCoin(int value = 1)
        {
            if (_levelFlow.CurrentWorld.CoinsCollected + 1 <= _levelFlow.CurrentWorld.CoinsTotal)
            {
                _levelFlow.CurrentWorld.CoinsCollected++;
            }

            Value++;
            _collectedCoinsText.text = $"{Value} / {_maxCoins}";
        }
    }
}
