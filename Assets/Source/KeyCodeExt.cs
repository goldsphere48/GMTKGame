using UnityEngine;

namespace Assets.Source
{
    public static class KeyCodeExt
    {
        public static int ToInt(this KeyCode key)
        {
            var first = (int)KeyCode.Alpha1;
            return (int)key - first + 1;
        }
    }
}
