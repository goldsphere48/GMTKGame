using TMPro;
using UnityEngine;

namespace GMTKGame.Menu
{
    internal class TimeView : MonoBehaviour
    {
        [SerializeField] private WorldData _worldData;
        [SerializeField] private TextMeshProUGUI _timeViewText;

        private void Awake()
        {
            _timeViewText.text = $"{_worldData.Time / 60} / {_worldData.Time % 60}";
        }
    }
}
