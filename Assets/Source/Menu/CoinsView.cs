using TMPro;
using UnityEngine;

namespace GMTKGame.Menu
{
    internal class CoinsView : MonoBehaviour
    {
        [SerializeField] private WorldData _worldData;
        [SerializeField] private TextMeshProUGUI _coinsCountText;

        private void Awake()
        {
            _coinsCountText.text = $"{_worldData.CoinsCollected} / {_worldData.CoinsTotal}";
        }
    }
}
