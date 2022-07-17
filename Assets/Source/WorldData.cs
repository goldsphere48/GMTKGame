using UnityEngine;

namespace GMTKGame
{
    [CreateAssetMenu(fileName = "World", menuName = "ScriptableObjects/WorldData", order = 1)]
    internal class WorldData : ScriptableObject
    {
        [SerializeField] private string _worldName;
        public int LastCheckpointId;
        private string WorldName => _worldName;
    }
}
