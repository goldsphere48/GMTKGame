using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTKGame;
using UnityEngine;

namespace Assets.Source
{
    internal class Cheats : MonoBehaviour
    {
        [SerializeField] private bool _clearDataOnStart;
        private World _world;

        private void Awake()
        {
            _world = GetComponent<World>();
#if DEBUG
            if (_clearDataOnStart)
            {
                ClearWorldData();
            }
#endif
        }

        public void ClearWorldData()
        {
            _world.WorldData.LastCheckpointId = 0;
        }
    }
}
