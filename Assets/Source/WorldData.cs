using UnityEngine;

namespace GMTKGame
{
    [CreateAssetMenu(fileName = "World Data", menuName = "World/World Data", order = 1)]
    public class WorldData : ScriptableObject
    {
        public string Name;
        public bool Completed;
        public bool Unlocked;
        public GameObject World;
        public int CoinsCollected;
        public int CoinsTotal;
        public int Time;
    }
}
