using UnityEngine;

namespace Assets.Source
{
    public static class KeyCodeExt
    {
        public static int ToInt(this KeyCode key)
        {
            switch (key)
            {
                case KeyCode.Keypad1:
                    return 1;
                case KeyCode.Keypad2:
                    return 2;
                case KeyCode.Keypad3:
                    return 3;
                case KeyCode.Keypad4:
                    return 4;
                case KeyCode.Keypad5:
                    return 5;
                case KeyCode.Keypad6:
                    return 6;

            }
            var first = (int)KeyCode.Alpha1;
            return (int)key - first + 1;
        }
    }
}
