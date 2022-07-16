using System;
using System.Collections.Generic;
using Assets.Source;
using UnityEngine;

namespace GMTKGame
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private List<KeyCode> _validKeyCodes;

        public event Action<int> NumberPressed; 

        private void Awake()
        {
            _validKeyCodes = new List<KeyCode>
            {
                KeyCode.Alpha1,
                KeyCode.Alpha2,
                KeyCode.Alpha3,
                KeyCode.Alpha4,
                KeyCode.Alpha5,
                KeyCode.Alpha6,
            };
        }

        void Update()
        {
            if (Input.anyKeyDown)
            {
                
            }
            foreach (var validKeyCode in _validKeyCodes)
            {
                if (Input.GetKeyDown(validKeyCode))
                {
                    NumberPressed?.Invoke(validKeyCode.ToInt());
                }
            }
        }
    }

}