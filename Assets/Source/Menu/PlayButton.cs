using UnityEngine;
using UnityEngine.SceneManagement;

namespace GMTKGame
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private WorldData _world;

        public void Play()
        {
            PlayerPrefs.SetString("InitialLevel", _world.Name);
            SceneManager.LoadScene("Play", LoadSceneMode.Single);
        }
    }

}