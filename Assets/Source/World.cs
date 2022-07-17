using UnityEngine;

namespace GMTKGame
{
    internal class World : MonoBehaviour
    {
        [SerializeField] private WorldData _worldData;

        public WorldData WorldData => _worldData;
    }
}
