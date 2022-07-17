using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GMTKGame
{
    public class PlayButtonLocker : MonoBehaviour
    {
        [SerializeField] private WorldData _worldData;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            // _button.enabled = _worldData.Unlocked;
        }
    }

}