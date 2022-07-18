using UnityEngine;

namespace GMTKGame
{
    public class HideHudCheat : MonoBehaviour
    {
        [SerializeField] private GameObject _hud;
        [SerializeField] private KeyCode _key = KeyCode.E;
        [SerializeField] private bool _enabled = true;

#if DEBUG
        void Update()
        {
            if (Input.GetKeyDown(_key))
            {
                _enabled = !_enabled;
                _hud.SetActive(_enabled);
            }
        }
#endif
    }

}